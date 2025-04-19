using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries
{

    public record GetAllTenderLocationsQuery : IRequest<List<TenderLocationDto>>;

}
