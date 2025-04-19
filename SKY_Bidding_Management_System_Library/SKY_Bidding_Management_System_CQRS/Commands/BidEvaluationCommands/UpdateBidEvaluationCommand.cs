using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands
{

    public record UpdateBidEvaluationCommand(int BidEvaluationId, int BidId, decimal BidEvaluationScore, string BidEvaluationNotes, DateTime EvaluatedAt) : IRequest<BidEvaluationDto>;

}
