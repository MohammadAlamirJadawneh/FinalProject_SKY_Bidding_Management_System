using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderAward_Queries
{
    public record GetAllTenderAwardsQuery : IRequest<List<TenderAwardDto>>;

}
