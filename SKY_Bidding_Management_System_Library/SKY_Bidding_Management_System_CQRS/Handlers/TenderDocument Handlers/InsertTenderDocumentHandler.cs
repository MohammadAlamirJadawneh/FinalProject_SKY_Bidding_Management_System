using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Handlers.TenderDocument_Handlers
{
    public record InsertTenderDocumentHandler(AppDbContext Db) : IRequestHandler<InsertTenderDocumentCommand, TenderDocumentDto>
    {
        public async Task<TenderDocumentDto> Handle(InsertTenderDocumentCommand request, CancellationToken cancellationToken)
        {
             var tenderExists = await Db.Tenders.AnyAsync(t => t.TenderId == request.TenderId, cancellationToken);
            if (!tenderExists)
            {
                throw new InvalidOperationException($"Tender with ID {request.TenderId} does not exist.");
            }

            var entity = new TenderDocument
            {
                TenderDocumentName = request.FileName,
                TenderDocumentContentType = request.ContentType,
                TenderDocumentData = request.Data,
                TenderId = request.TenderId,
                TenderDocumentUploadedDate = DateTime.UtcNow
            };

            Db.TenderDocuments.Add(entity);
            await Db.SaveChangesAsync(cancellationToken);

            return new TenderDocumentDto(
                entity.TenderDocumentId,
                entity.TenderDocumentName,
                entity.TenderDocumentContentType,
                entity.TenderDocumentUploadedDate
            );
        }
    }
     


}
