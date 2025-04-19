using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands
{
    public record DeleteTenderCommand(int TenderId) : IRequest<bool>;

}
