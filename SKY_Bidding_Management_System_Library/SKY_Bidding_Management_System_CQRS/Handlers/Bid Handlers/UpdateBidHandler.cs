using MediatR;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;
using System.Security.Claims;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record UpdateBidCommandHandler(AppDbContext Context, IHttpContextAccessor _httpContextAccessor) : IRequestHandler<UpdateBidCommand, BidDto>
    {
        public async Task<BidDto> Handle(UpdateBidCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var bid = await Context.Bids.FindAsync(request.BidId);
            if (bid == null) return null;

            var DateNow = DateTime.Now;

            var isTenderOpen = Context.Tenders
        .Any(t => t.TenderId == request.TenderId && t.TenderClosingDate >= DateTime.Now);

            if (isTenderOpen)
            {
                bid.TenderId = request.TenderId;
                bid.BidderId = userId;
                bid.SubmissionDate = request.SubmissionDate;
                bid.TechnicalSummary = request.TechnicalSummary;
                bid.CompanyName = request.CompanyName;
                bid.RegistrationNumber = request.RegistrationNumber;
                bid.Address = request.Address;
                bid.Email = request.Email;
                bid.Phone = request.Phone;


                foreach (var documentId in request.BidDocumentIds)
                {
                    var bidDocument = await Context.BidDocuments.FindAsync(documentId);
                    if (bidDocument != null)
                    {
                        bid.BidDocument.Add(bidDocument);
                    }
                }

                await Context.SaveChangesAsync(cancellationToken);

                return new BidDto(
                    bid.BidId,
                    bid.TenderId,
                    bid.BidderId,
                    bid.SubmissionDate,
                    bid.BidDocument?.Select(d => new BidDocumentDto(
                        d.BidDocumentId,
                        d.BidDocumentName,
                        d.BidDocumentContentType,
                        d.BidDocumentUploadedDate
                    )).ToList()
                );
            }
            else
            {

                throw new InvalidOperationException($"Cannot Update bid. Tender with ID '{request.TenderId}' is closed.");

            }
        }
    }

    


}
