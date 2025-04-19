using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands
{

    public record DeleteTenderEvaluationCommand(int TenderEvaluationId) : IRequest<bool>;

}
