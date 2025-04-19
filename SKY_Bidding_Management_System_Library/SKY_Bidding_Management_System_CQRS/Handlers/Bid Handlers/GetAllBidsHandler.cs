using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record GetAllBidsQueryHandler(AppDbContext Context) : IRequestHandler<GetAllBidsQuery, List<BidDto>>
    {
        public async Task<List<BidDto>> Handle(GetAllBidsQuery request, CancellationToken cancellationToken)
        {
            var bids = await Context.Bids.Include(b => b.BidDocument).ToListAsync(cancellationToken);

            return bids.Select(bid => new BidDto(
                bid.BidId,
                bid.TenderId,
                bid.BidderId,
                bid.SubmissionDate,
                bid.BidDocument.Select(d => new BidDocumentDto(
                    d.BidDocumentId,
                    d.BidDocumentName,
                    d.BidDocumentContentType,
                    d.BidDocumentUploadedDate
                )).ToList()
            )).ToList();
        }
    }
 

}
