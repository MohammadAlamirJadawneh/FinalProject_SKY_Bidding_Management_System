using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{


    
    public record GetBidWithDocumentsHandler(AppDbContext Context) : IRequestHandler<GetBidWithDocumentsQuery, BidDto>
    {
        public async Task<BidDto> Handle(GetBidWithDocumentsQuery request, CancellationToken cancellationToken)
        {
            var bid = await Context.Bids
                .Include(b => b.BidDocument)
                .FirstOrDefaultAsync(b => b.BidId == request.BidId, cancellationToken);

            if (bid == null)
            {
                throw new KeyNotFoundException($"Bid with ID {request.BidId} not found.");
            }

            return new BidDto(
                bid.BidId,
                bid.TenderId,
                bid.BidderId,
                bid.SubmissionDate,
                bid.BidDocument.Select(doc => new BidDocumentDto(
                    doc.BidDocumentId,
                    doc.BidDocumentName,
                    doc.BidDocumentContentType,
                    doc.BidDocumentUploadedDate,
                    doc.BidDocumentData
                )).ToList()
            );
        }
    }


}
