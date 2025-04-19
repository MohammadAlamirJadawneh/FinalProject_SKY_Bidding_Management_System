using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record GetTenderScopeHandler(AppDbContext Context)
    : IRequestHandler<GetTenderScopeQuery, TenderScopeDto>
    {
        public async Task<TenderScopeDto> Handle(GetTenderScopeQuery request, CancellationToken cancellationToken)
        {
            var tender = await Context.Tenders
                .Include(t => t.TenderCategory)
                .Include(t => t.TenderType)
                .FirstOrDefaultAsync(t => t.TenderId == request.TenderId, cancellationToken);

            if (tender == null)
                throw new Exception("Tender not found.");

            return new TenderScopeDto
            {
                ProjectDescription = tender.TenderDescription,
                Deliverables = new List<string>
            {
                "Development of a software solution",  
                "Construction of infrastructure" 
            },
                ExpectedTimeline = new List<TenderTimelineItem>
            {
                new TenderTimelineItem
                {
                    Activity = "Tender Publish",
                    ExpectedDate = tender.TenderIssueDate
                },
                new TenderTimelineItem
                {
                    Activity = "Bid Submission Deadline",
                    ExpectedDate = tender.TenderClosingDate
                },
                new TenderTimelineItem
                {
                    Activity = "Bid Evaluation",
                    ExpectedDate = DateTime.Now.AddDays(10)  
                }
            }
            };
        }
    }
     
}
