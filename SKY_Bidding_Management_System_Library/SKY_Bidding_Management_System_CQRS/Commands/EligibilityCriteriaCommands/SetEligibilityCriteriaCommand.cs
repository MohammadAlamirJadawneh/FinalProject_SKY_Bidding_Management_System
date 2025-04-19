using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.EligibilityCriteriaCommands
{
    public record SetEligibilityCriteriaCommand(
    int TenderId,   bool IsRegisteredCompany, bool HasMinimumExperience, 
    bool IsFinanciallyStable, bool HasPastExperience, bool CompliesWithIndustryStandards) : IRequest;
     

}
