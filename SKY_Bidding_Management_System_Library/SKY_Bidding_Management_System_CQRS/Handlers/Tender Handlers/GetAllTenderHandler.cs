using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record GetAllTenderHandler(AppDbContext Db)
    : IRequestHandler<GetAllTenderQuery, List<TenderDto>>
    {
        public async Task<List<TenderDto>> Handle(GetAllTenderQuery request, CancellationToken cancellationToken)
        {
            var tenders = await Db.Tenders
                .Select(t => new TenderDto
                {
                    TenderId = t.TenderId,
                    TenderIssuedBy = t.TenderIssuedBy,
                    TenderTitle = t.TenderTitle,
                    TenderDescription = t.TenderDescription,
                    TenderBudget = t.TenderBudget,
                    TenderIssueDate = t.TenderIssueDate,
                    TenderClosingDate = t.TenderClosingDate,
                    TenderStatus = (t.TenderClosingDate >= DateTime.Now)
                        ? TenderStatusEnum.Open 
                        : TenderStatusEnum.Closed ,
                    Email = t.Email,
                    EligibilityCriteria = t.EligibilityCriteria,
                    CategoryId = t.CategoryId,
                    IndustryId = t.IndustryId,
                    TenderTypeId = t.TenderTypeId,
                    LocationId = t.LocationId
                })
                .ToListAsync(cancellationToken);

            return tenders;
        }
    }
     
}
