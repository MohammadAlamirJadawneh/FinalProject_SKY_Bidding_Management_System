using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record DeleteBidCommandHandler(AppDbContext Context) : IRequestHandler<DeleteBidCommand, bool>
    {
        public async Task<bool> Handle(DeleteBidCommand request, CancellationToken cancellationToken)
        {
            var bid = await Context.Bids.FindAsync(request.BidId);
            if (bid == null) return false;

            var DateNow = DateTime.Now;

            var isTenderOpen = Context.Tenders
        .Any(t => t.TenderId == request.TenderId && t.TenderClosingDate >= DateTime.Now);

            if (isTenderOpen)
            {
                Context.Bids.Remove(bid);
                await Context.SaveChangesAsync(cancellationToken);

                return true;
            }
            else
            {

                throw new InvalidOperationException($"Cannot Delete bid. Tender with ID '{request.TenderId}' is closed.");

            }
        }
    }

 




}
