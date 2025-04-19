using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Handlers.TenderDocument_Handlers
{
    public record UpdateTenderDocumentCommandHandler(AppDbContext Db) : IRequestHandler<UpdateTenderDocumentCommand, TenderDocumentDto>
    {
        public async Task<TenderDocumentDto> Handle(UpdateTenderDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await Db.TenderDocuments
                .FirstOrDefaultAsync(d => d.TenderDocumentId == request.TenderDocumentId, cancellationToken);

            if (document == null)
                throw new ArgumentException($"Tender Document with ID {request.TenderDocumentId} was not found.");

          
            document.TenderDocumentName = request.FileName;
            document.TenderDocumentContentType = request.ContentType;
            document.TenderDocumentData = request.Data;
            document.TenderDocumentUploadedDate = DateTime.UtcNow;

            await Db.SaveChangesAsync(cancellationToken);

            return new TenderDocumentDto(
                document.TenderDocumentId,
                document.TenderDocumentName,
                document.TenderDocumentContentType,
                document.TenderDocumentUploadedDate
            );
        }
    }

     

}
