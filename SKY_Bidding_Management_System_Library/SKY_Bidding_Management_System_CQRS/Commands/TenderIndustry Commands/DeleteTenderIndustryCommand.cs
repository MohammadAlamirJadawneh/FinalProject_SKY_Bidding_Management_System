using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands
{

    public record DeleteTenderIndustryCommand(int TenderIndustryId) : IRequest<bool>;

}
