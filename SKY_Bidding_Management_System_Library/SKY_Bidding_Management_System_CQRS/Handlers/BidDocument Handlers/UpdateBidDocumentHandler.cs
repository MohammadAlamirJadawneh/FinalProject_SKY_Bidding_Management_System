using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidDocument_Handlers
{
    public record UpdateBidDocumentCommandHandler(AppDbContext Db) : IRequestHandler<UpdateBidDocumentCommand, BidDocumentDto>
    {
        public async Task<BidDocumentDto> Handle(UpdateBidDocumentCommand request, CancellationToken cancellationToken)
        {
            
            var entity = await Db.BidDocuments.FindAsync(request.BidDocumentId);

            
            if (entity == null)
                throw new KeyNotFoundException("Bid document not found.");

        
            entity.BidDocumentName = request.FileName;
            entity.BidDocumentContentType = request.ContentType;
            entity.BidDocumentData = request.Data;  

            
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
