using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record GetTenderByIdHandler(AppDbContext DbContext)
    : IRequestHandler<GetTenderByIdQuery, TenderDto>
    {
        public async Task<TenderDto> Handle(GetTenderByIdQuery request, CancellationToken cancellationToken)
        {
            var tender = await DbContext.Tenders
                .Where(t => t.TenderId == request.TenderId)
                .Select(t => new TenderDto
                {
                    TenderId = t.TenderId,
                    TenderIssuedBy = t.TenderIssuedBy,
                    TenderTitle = t.TenderTitle,
                    TenderDescription = t.TenderDescription,
                    TenderBudget = t.TenderBudget,
                    TenderIssueDate = t.TenderIssueDate,
                    TenderClosingDate = t.TenderClosingDate,
                    TenderStatus = (t.TenderClosingDate >= DateTime.Now) ? TenderStatusEnum.Open : TenderStatusEnum.Closed ,
                    Email = t.Email,
                    EligibilityCriteria = t.EligibilityCriteria,
                    CategoryId = t.CategoryId,
                    IndustryId = t.IndustryId,
                    TenderTypeId = t.TenderTypeId,
                    LocationId = t.LocationId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tender;
        }
    }
 
}
