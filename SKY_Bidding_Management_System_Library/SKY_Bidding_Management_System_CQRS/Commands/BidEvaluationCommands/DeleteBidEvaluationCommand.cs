using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands
{

    public record DeleteBidEvaluationCommand(int BidEvaluationId) : IRequest<bool>;

}
