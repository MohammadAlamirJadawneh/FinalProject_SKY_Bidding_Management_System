using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SubmissionGuidelinesQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SubmissionGuidelinesHandlers
{
    public record GetSubmissionGuidelinesHandler(AppDbContext Context) : IRequestHandler<GetSubmissionGuidelinesQuery, List<SubmissionGuidelineDto>>
    {
        public async Task<List<SubmissionGuidelineDto>> Handle(GetSubmissionGuidelinesQuery request, CancellationToken cancellationToken)
        {
            
            return await Context.SubmissionGuidelines
                .Where(sg => sg.TenderId == request.TenderId)  
                .Select(sg => new SubmissionGuidelineDto
                {
                    TenderId = sg.TenderId,
                    TechnicalProposal = sg.TechnicalProposal,
                    FinancialProposal = sg.FinancialProposal,
                    CompanyProfile = sg.CompanyProfile
                })
                .ToListAsync(cancellationToken);  
        }
    }
     


}
