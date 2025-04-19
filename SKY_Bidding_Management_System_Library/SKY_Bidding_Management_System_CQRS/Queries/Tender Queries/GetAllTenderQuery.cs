using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries
{
    public record GetAllTenderQuery : IRequest<List<TenderDto>>;

}
