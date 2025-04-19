using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands
{
    public record UpdateTenderAwardCommand(int TenderAwardId, int TenderId, int BidId, DateTime AwardDate, string AwardStatus) : IRequest<TenderAwardDto>;

}
