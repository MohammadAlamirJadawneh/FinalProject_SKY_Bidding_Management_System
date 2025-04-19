using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands
{
    public record DeleteTenderAwardCommand(int TenderAwardId) : IRequest<bool>;

}
