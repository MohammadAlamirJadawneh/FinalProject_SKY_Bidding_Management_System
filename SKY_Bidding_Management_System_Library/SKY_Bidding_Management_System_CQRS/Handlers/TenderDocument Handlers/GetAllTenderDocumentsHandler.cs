using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Queries.TenderDocument_Queries;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Handlers.TenderDocument_Handlers
{
    public record GetAllTenderDocumentsHandler(AppDbContext Db) : IRequestHandler<GetAllTenderDocumentsQuery, List<TenderDocumentDto>>
    {
        public async Task<List<TenderDocumentDto>> Handle(GetAllTenderDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await Db.TenderDocuments
                .Select(doc => new TenderDocumentDto(
                    doc.TenderDocumentId,
                    doc.TenderDocumentName,
                    doc.TenderDocumentContentType,
                    doc.TenderDocumentUploadedDate,
                    doc.TenderDocumentData
                ))
                .ToListAsync(cancellationToken);

            return documents;
        }
    }
 


}
