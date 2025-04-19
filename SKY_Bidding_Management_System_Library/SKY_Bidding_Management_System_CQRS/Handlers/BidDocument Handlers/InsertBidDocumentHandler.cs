using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidDocument_Handlers
{
    public record InsertBidDocumentCommandHandler(AppDbContext Db) : IRequestHandler<InsertBidDocumentCommand, BidDocumentDto>
    {
        public async Task<BidDocumentDto> Handle(InsertBidDocumentCommand request, CancellationToken cancellationToken)
        {
            var bidExists = await Db.Bids.AnyAsync(b => b.BidId == request.BidId, cancellationToken);
            if (!bidExists)
                throw new ArgumentException("Bid not found");

            var entity = new BidDocument
            {
                BidDocumentName = request.FileName,
                BidDocumentContentType = request.ContentType,
                BidDocumentData = request.Data,
                BidId = request.BidId,
                BidDocumentUploadedDate = DateTime.UtcNow
            };

            Db.BidDocuments.Add(entity);
            await Db.SaveChangesAsync(cancellationToken);

            return new BidDocumentDto(
                entity.BidDocumentId,
                entity.BidDocumentName,
                entity.BidDocumentContentType,
                entity.BidDocumentUploadedDate
            );
        }
    }

     




}
