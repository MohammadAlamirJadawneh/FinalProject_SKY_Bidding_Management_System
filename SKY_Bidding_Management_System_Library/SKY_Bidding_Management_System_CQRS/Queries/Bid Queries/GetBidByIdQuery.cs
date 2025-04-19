using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries
{
 
    public record GetBidByIdQuery(int BidId) : IRequest<BidDto>;

}
