using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidDocument_Queries
{
    public record GetAllBidDocumentsQuery() : IRequest<List<BidDocumentDto>>;

}
