using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderDocument_Handlers
{
    public record GetTenderByIdQueryHandler(AppDbContext Context)
    : IRequestHandler<GetTenderByIdQuery, TenderDto>
    {
        public async Task<TenderDto> Handle(GetTenderByIdQuery request, CancellationToken cancellationToken)
        {
            
            var tender = await Context.Tenders
                .Include(t => t.TenderCategory)  
                .Include(t => t.TenderIndustry)
                .Include(t => t.TenderType)
                .Include(t => t.TenderLocation)
                .FirstOrDefaultAsync(t => t.TenderId == request.TenderId, cancellationToken);

            if (tender == null)
            {
                throw new Exception("Tender not found.");
            }
 
            return new TenderDto
            {
                TenderId = tender.TenderId,
                TenderIssuedBy = tender.TenderIssuedBy,
                TenderTitle = tender.TenderTitle,
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
 
                TenderCategoryName = tender.TenderCategory?.TenderCategoryName,
                TenderIndustryName = tender.TenderIndustry?.TenderIndustryName,
                TenderTypeName = tender.TenderType?.TenderTypeName,
                TenderLocationName = tender.TenderLocation?.TenderLocationName,
            };
        }
    }
 







}
