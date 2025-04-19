using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.SupportingDocumentsText;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SupportingDocumentsTextQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SupportingDocumentsTextHandlers
{
    public record GetSupportingDocumentsQueryHandler(AppDbContext Context) : IRequestHandler<GetSupportingDocumentsQuery, List<SupportingDocumentDto>>
    {
        public async Task<List<SupportingDocumentDto>> Handle(GetSupportingDocumentsQuery request, CancellationToken cancellationToken)
        {
            
            var documents = await Context.SupportingDocuments
                .Where(doc => doc.BidId == request.BidId)
                .Select(doc => new SupportingDocumentDto
                {
                    DocumentName = doc.DocumentName,
                    Description = doc.Description
                })
                .ToListAsync(cancellationToken);

            return documents;
        }
    }
     
}