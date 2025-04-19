using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands
{

    public record InsertBidEvaluationCommand(InsertBidEvaluationDto BidEvaluation) : IRequest<BidEvaluationDto>;

}
