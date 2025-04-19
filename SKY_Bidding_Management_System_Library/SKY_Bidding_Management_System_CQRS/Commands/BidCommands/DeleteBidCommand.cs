using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands
{
     public record DeleteBidCommand(int BidId, int TenderId) : IRequest<bool>;




}
