using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands
{
    public record DeleteBidDocumentCommand(int BidDocumentId) : IRequest<bool>;

}
