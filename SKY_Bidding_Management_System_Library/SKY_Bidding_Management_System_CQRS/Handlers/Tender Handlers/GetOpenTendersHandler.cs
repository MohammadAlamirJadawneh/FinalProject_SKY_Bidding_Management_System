using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record GetOpenTendersQueryHandler(AppDbContext DbContext)
    : IRequestHandler<GetOpenTendersQuery, IEnumerable<TenderDto>>
    {
        public async Task<IEnumerable<TenderDto>> Handle(GetOpenTendersQuery request, CancellationToken cancellationToken)
        {
            var tenders = await DbContext.Set<Tender>()
                .Where(t => t.TenderClosingDate >= DateTime.Now)
                .Select(tender => new TenderDto
                {
                    TenderId = tender.TenderId,
                    TenderIssuedBy = tender.TenderIssuedBy,
                    TenderTitle = tender.TenderTitle,
                    TenderDescription = tender.TenderDescription,
                    TenderBudget = tender.TenderBudget,
                    TenderIssueDate = tender.TenderIssueDate,
                    TenderClosingDate = tender.TenderClosingDate,
                    TenderStatus = (tender.TenderClosingDate >= DateTime.Now) ? TenderStatusEnum.Open  : TenderStatusEnum.Closed ,
                    Email = tender.Email,
                    EligibilityCriteria = tender.EligibilityCriteria,
                    CategoryId = tender.CategoryId,
                    IndustryId = tender.IndustryId,
                    TenderTypeId = tender.TenderTypeId,
                    LocationId = tender.LocationId,
                    TenderCategoryName = tender.TenderCategory != null ? tender.TenderCategory.TenderCategoryName : null,
                    TenderIndustryName = tender.TenderIndustry != null ? tender.TenderIndustry.TenderIndustryName : null,
                    TenderTypeName = tender.TenderType != null ? tender.TenderType.TenderTypeName : null,
                    TenderLocationName = tender.TenderLocation != null ? tender.TenderLocation.TenderLocationName : null
                })
                .ToListAsync(cancellationToken);

            return tenders;
        }
    }
     
}



