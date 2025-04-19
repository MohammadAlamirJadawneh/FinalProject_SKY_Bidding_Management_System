using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Queries.TenderDocument_Queries
{
    public record GetAllTenderDocumentsQuery() : IRequest<List<TenderDocumentDto>>;

}
