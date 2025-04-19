using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{

    public record GetBidByIdQueryHandler(AppDbContext Context) : IRequestHandler<GetBidByIdQuery, BidDto>
    {
        public async Task<BidDto> Handle(GetBidByIdQuery request, CancellationToken cancellationToken)
        {
            var bid = await Context.Bids.Include(b => b.BidDocument)
                                         .FirstOrDefaultAsync(b => b.BidId == request.BidId, cancellationToken);
            if (bid == null) return null;

            return new BidDto(
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
            );
        }
    }

     
}
