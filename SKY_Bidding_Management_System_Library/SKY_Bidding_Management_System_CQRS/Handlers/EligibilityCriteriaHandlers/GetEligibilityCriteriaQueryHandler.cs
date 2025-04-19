using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.EligibilityCriteriaQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.EligibilityCriteriaHandlers
{
    public record GetEligibilityCriteriaQueryHandler(AppDbContext Context) : IRequestHandler<GetEligibilityCriteriaQuery, EligibilityCriteriaDto>
    {
        public async Task<EligibilityCriteriaDto> Handle(GetEligibilityCriteriaQuery request, CancellationToken cancellationToken)
        {
         
            var tenderEligibility = await Context.TenderEligibilities
                .Include(te => te.Tender)
                .FirstOrDefaultAsync(te => te.TenderId == request.TenderId, cancellationToken);

            if (tenderEligibility == null)
                throw new Exception("Eligibility criteria not found for the specified tender.");

            
            var eligibilityDto = new EligibilityCriteriaDto
            {
                TenderId = tenderEligibility.TenderId,
                IsRegisteredCompany = tenderEligibility.IsRegisteredCompany,
                HasMinimumExperience = tenderEligibility.HasMinimumExperience,
                IsFinanciallyStable = tenderEligibility.IsFinanciallyStable,
                HasPastExperience = tenderEligibility.HasPastExperience,
                CompliesWithIndustryStandards = tenderEligibility.CompliesWithIndustryStandards
            };

            return eligibilityDto;
        }
    }
     



}
