using MediatR;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;
using System.Security.Claims;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record UpdateTenderHandler(AppDbContext Db , IHttpContextAccessor _httpContextAccessor) : IRequestHandler<UpdateTenderCommand, TenderDto>
    {
        public async Task<TenderDto> Handle(UpdateTenderCommand request, CancellationToken cancellationToken)
        {
            var tender = await Db.Tenders.FindAsync(request.TenderId);

            if (tender == null)
            {
                throw new Exception("Tender not found.");
            }
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            tender.TenderIssuedBy = userId;
            tender.TenderTitle = request.TenderTitle;
            tender.TenderDescription = request.TenderDescription;
            tender.TenderBudget = request.TenderBudget;
            tender.TenderIssueDate = request.TenderIssueDate;
            tender.TenderClosingDate = request.TenderClosingDate;
            tender.TenderStatus = (request.TenderClosingDate >= DateTime.Now) ? TenderStatusEnum.Open  : TenderStatusEnum.Closed ;

            tender.Email = request.Email;
            tender.EligibilityCriteria = request.EligibilityCriteria;
            tender.CategoryId = request.CategoryId;
            tender.IndustryId = request.IndustryId;
            tender.TenderTypeId = request.TenderTypeId;
            tender.LocationId = request.LocationId;

            await Db.SaveChangesAsync(cancellationToken);

            return new TenderDto
            {
                TenderId = tender.TenderId,
                TenderIssuedBy = tender.TenderIssuedBy,
                TenderTitle = tender.TenderTitle,
                TenderDescription = tender.TenderDescription,
                TenderBudget = tender.TenderBudget,
                TenderIssueDate = tender.TenderIssueDate,
                TenderClosingDate = tender.TenderClosingDate,
                Email = tender.Email,
                EligibilityCriteria = tender.EligibilityCriteria,
                CategoryId = tender.CategoryId,
                IndustryId = tender.IndustryId,
                TenderTypeId = tender.TenderTypeId,
                LocationId = tender.LocationId
            };
        }
    }
     
}
