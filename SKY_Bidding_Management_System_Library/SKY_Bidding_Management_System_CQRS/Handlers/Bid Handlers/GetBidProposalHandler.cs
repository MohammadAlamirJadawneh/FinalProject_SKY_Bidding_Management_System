using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{

    public record GetBidProposalHandler(AppDbContext Context) : IRequestHandler<GetBidProposalQuery, BidProposalDto>
    {
        public async Task<BidProposalDto> Handle(GetBidProposalQuery request, CancellationToken cancellationToken)
        {
             var bid = await Context.Bids
                .Include(b => b.FinancialProposalItems)  
                .FirstOrDefaultAsync(b => b.BidId == request.BidId, cancellationToken);

            if (bid == null)
            {
                return null;
            }

             return new BidProposalDto
            {
                BidId = bid.BidId,
                TechnicalSummary = bid.TechnicalSummary,  
                FinancialProposalItems = bid.FinancialProposalItems.Select(item => new FinancialProposalItemDto(
                    item.ItemDescription,
                    item.Quantity,
                    item.UnitPrice,
                    item.TotalPrice
                )).ToList()
            };
        }
    }
     


}
