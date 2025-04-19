using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands
{
    public record DeleteTenderLocationCommand(int TenderLocationId) : IRequest<bool>;

}
