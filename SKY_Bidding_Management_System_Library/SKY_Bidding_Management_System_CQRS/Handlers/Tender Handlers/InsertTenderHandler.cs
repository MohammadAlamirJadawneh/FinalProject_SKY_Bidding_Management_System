using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;
using System.Security.Claims;
using TenderDocumentDtoNamespace = SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record InsertTenderCommandHandler(AppDbContext Context, IWebHostEnvironment Environment, IHttpContextAccessor _httpContextAccessor)
    : IRequestHandler<InsertTenderCommand, TenderDto>
    {
        public async Task<TenderDto> Handle(InsertTenderCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var webRootPath = Environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadPath = Path.Combine(webRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var tender = new Tender
            {
                TenderTitle = request.TenderTitle,
                TenderDescription = request.TenderDescription,
                TenderIssuedBy = userId,
                TenderBudget = request.TenderBudget,
                TenderIssueDate = request.TenderIssueDate,
                TenderClosingDate = request.TenderClosingDate,
                TenderStatus = (request.TenderClosingDate >= DateTime.Now) ? TenderStatusEnum.Open  : TenderStatusEnum.Closed ,
                Email = request.Email,
                EligibilityCriteria = request.EligibilityCriteria,
                CategoryId = request.CategoryId,
                IndustryId = request.IndustryId,
                TenderTypeId = request.TenderTypeId,
                LocationId = request.LocationId
            };

            Context.Tenders.Add(tender);
            await Context.SaveChangesAsync(cancellationToken);

            var tenderDocuments = new List<TenderDocument>();
            if (request.Files != null)
            {
                foreach (var file in request.Files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(uploadPath, file.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var tenderDocument = new TenderDocument
                        {
                            TenderDocumentName = file.FileName,
                            TenderDocumentContentType = file.ContentType,
                            TenderDocumentData = await File.ReadAllBytesAsync(filePath),
                            TenderDocumentUploadedDate = DateTime.UtcNow,
                            TenderId = tender.TenderId
                        };

                        tenderDocuments.Add(tenderDocument);
                    }
                }
            }

            if (tenderDocuments.Any())
            {
                Context.TenderDocuments.AddRange(tenderDocuments);
                await Context.SaveChangesAsync(cancellationToken);
            }

            var tenderDto = new TenderDto
            {
                TenderId = tender.TenderId,
                TenderTitle = tender.TenderTitle,
                TenderIssuedBy = tender.TenderIssuedBy,
                TenderDescription = tender.TenderDescription,
                TenderBudget = tender.TenderBudget,
                TenderIssueDate = tender.TenderIssueDate,
                TenderClosingDate = tender.TenderClosingDate,
                TenderStatus = tender.TenderStatus,
                Email = tender.Email,
                EligibilityCriteria = tender.EligibilityCriteria,
                CategoryId = tender.CategoryId,
                IndustryId = tender.IndustryId,
                TenderTypeId = tender.TenderTypeId,
                LocationId = tender.LocationId,
                TenderDocuments = tenderDocuments.Select(doc => new TenderDocumentDtoNamespace.TenderDocumentDto(
                    doc.TenderDocumentId,                    
                    doc.TenderDocumentName,                  
                    doc.TenderDocumentContentType,           
                    doc.TenderDocumentUploadedDate,          
                    doc.TenderDocumentData                   
                )).ToList()
            };

            return tenderDto;
        }
    }
 


}
