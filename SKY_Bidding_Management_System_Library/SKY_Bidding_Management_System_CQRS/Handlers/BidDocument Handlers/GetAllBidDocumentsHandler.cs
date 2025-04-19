using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidDocument_Queries;
namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidDocument_Handlers
{
    public class GetAllBidDocumentsHandler : IRequestHandler<GetAllBidDocumentsQuery, List<BidDocumentDto>>
    {
        private readonly AppDbContext _db;

        public GetAllBidDocumentsHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<BidDocumentDto>> Handle(GetAllBidDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _db.BidDocuments
    .Select(doc => new BidDocumentDto(
        doc.BidDocumentId,
        doc.BidDocumentName,
        doc.BidDocumentContentType,
        doc.BidDocumentUploadedDate,
      doc.BidDocumentData
    ))
            .ToListAsync(cancellationToken);


            return documents;
        }
    }
   

}
