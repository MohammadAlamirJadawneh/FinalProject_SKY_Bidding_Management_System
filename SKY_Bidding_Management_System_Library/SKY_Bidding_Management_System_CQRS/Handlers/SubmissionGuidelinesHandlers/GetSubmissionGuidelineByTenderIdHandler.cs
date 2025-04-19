using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SubmissionGuidelinesQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SubmissionGuidelinesHandlers
{
    public record GetSubmissionGuidelineByTenderIdQueryHandler(AppDbContext DbContext) : IRequestHandler<GetSubmissionGuidelineByTenderIdQuery, SubmissionGuidelineDto>
    {
        public async Task<SubmissionGuidelineDto> Handle(GetSubmissionGuidelineByTenderIdQuery request, CancellationToken cancellationToken)
        {
            var submissionGuideline = await DbContext.SubmissionGuidelines
                .Where(sg => sg.TenderId == request.TenderId)
                .FirstOrDefaultAsync(cancellationToken);

            if (submissionGuideline == null)
            {
                throw new Exception($"Submission guidelines not found for tender with ID {request.TenderId}");
            }

            return new SubmissionGuidelineDto
            {
                TenderId = submissionGuideline.TenderId,
                TechnicalProposal = submissionGuideline.TechnicalProposal,
                FinancialProposal = submissionGuideline.FinancialProposal,
                CompanyProfile = submissionGuideline.CompanyProfile
            };
        }
    }
     



}
