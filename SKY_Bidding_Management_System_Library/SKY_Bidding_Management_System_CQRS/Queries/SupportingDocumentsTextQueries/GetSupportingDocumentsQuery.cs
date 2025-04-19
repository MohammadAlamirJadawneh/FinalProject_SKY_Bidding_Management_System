using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.SupportingDocumentsText;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SupportingDocumentsTextQueries
{
    public record GetSupportingDocumentsQuery(int BidId) : IRequest<List<SupportingDocumentDto>>;

   
}
