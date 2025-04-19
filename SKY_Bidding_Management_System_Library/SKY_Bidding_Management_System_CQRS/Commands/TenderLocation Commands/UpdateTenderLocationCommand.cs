using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands
{

    public record UpdateTenderLocationCommand(int tenderLocationId, string tenderLocationName) : IRequest<TenderLocationDto>;

}
