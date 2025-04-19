using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;
using System.Security.Claims;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record InsertBidCommandHandler(AppDbContext Context, IWebHostEnvironment Environment, IHttpContextAccessor _httpContextAccessor) : IRequestHandler<InsertBidCommand, BidDto>
    {
        public async Task<BidDto> Handle(InsertBidCommand request, CancellationToken cancellationToken)
        {

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var DateNow = DateTime.Now;

            var isTenderOpen = Context.Tenders
        .Any(t => t.TenderId == request.TenderId && t.TenderClosingDate >= DateTime.Now);

            if (isTenderOpen)
            {
                var webRootPath = Environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");


                var uploadPath = Path.Combine(webRootPath, "uploads");


                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }


                var bid = new Bid
                {
                    TenderId = request.TenderId,
                    BidderId = userId,
                    SubmissionDate = request.SubmissionDate,
                    Phone = request.Phone,
                    Email = request.Email,
                    TechnicalSummary = request.TechnicalSummary,
                    CompanyName = request.CompanyName,
                    RegistrationNumber = request.RegistrationNumber,
                    Address = request.Address,
                };

                Context.Bids.Add(bid);
                await Context.SaveChangesAsync(cancellationToken);


                var bidDocuments = new List<BidDocument>();

                foreach (var file in request.Files)
                {

                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(uploadPath, file.FileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }


                        var bidDocument = new BidDocument
                        {
                            BidDocumentName = file.FileName,
                            BidDocumentContentType = file.ContentType,
                            BidDocumentData = await File.ReadAllBytesAsync(filePath),
                            BidDocumentUploadedDate = DateTime.UtcNow,
                            BidId = bid.BidId
                        };

                        bidDocuments.Add(bidDocument);
                    }
                }

                if (bidDocuments.Any())
                {
                    Context.BidDocuments.AddRange(bidDocuments);
                    await Context.SaveChangesAsync(cancellationToken);
                }

                var bidDto = new BidDto(
                   bid.BidId,
                   bid.TenderId,
                   bid.BidderId,
                   bid.SubmissionDate,
                   bidDocuments.Select(doc => new BidDocumentDto(
                       doc.BidDocumentId,
                       doc.BidDocumentName,
                       doc.BidDocumentContentType,
                       doc.BidDocumentUploadedDate
                   )).ToList(),
                   bid.TechnicalSummary,
                   bid.FinancialProposalItems?.Select(item => new FinancialProposalItemDto(
                       item.ItemDescription,
                       item.Quantity,
                       item.UnitPrice,
                       item.TotalPrice
                   )).ToList(),
                   bid.CompanyName,
                   bid.RegistrationNumber,
                   bid.Address,
                   bid.Email,
                   bid.Phone
               );

                return bidDto;
            }
            else
            {

                throw new InvalidOperationException($"Cannot submit bid. Tender with ID '{request.TenderId}' is closed.");

            }
        }
    }





}
