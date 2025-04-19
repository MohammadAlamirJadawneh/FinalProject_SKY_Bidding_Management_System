using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.EligibilityCriteriaCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SetEligibilityCriteriaHandlers
{
    public record SetEligibilityCriteriaCommandHandler(AppDbContext Context) : IRequestHandler<SetEligibilityCriteriaCommand>
    {
        public async Task Handle(SetEligibilityCriteriaCommand request, CancellationToken cancellationToken)
        {
            
            var eligibility = await Context.TenderEligibilities
                .FirstOrDefaultAsync(e => e.TenderId == request.TenderId, cancellationToken);

            if (eligibility == null)
            {
     
                eligibility = new TenderEligibility
                {
                    TenderId = request.TenderId,
                    IsRegisteredCompany = request.IsRegisteredCompany,
                    HasMinimumExperience = request.HasMinimumExperience,
                    IsFinanciallyStable = request.IsFinanciallyStable,
                    HasPastExperience = request.HasPastExperience,
                    CompliesWithIndustryStandards = request.CompliesWithIndustryStandards
                };

                Context.TenderEligibilities.Add(eligibility);
            }
            else
            {
                
                eligibility.IsRegisteredCompany = request.IsRegisteredCompany;
                eligibility.HasMinimumExperience = request.HasMinimumExperience;
                eligibility.IsFinanciallyStable = request.IsFinanciallyStable;
                eligibility.HasPastExperience = request.HasPastExperience;
                eligibility.CompliesWithIndustryStandards = request.CompliesWithIndustryStandards;
            }

             
             await Context.SaveChangesAsync(cancellationToken);
        }
    }
     

}
