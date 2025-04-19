using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands
{
     public record InsertTenderEvaluationCommand(InsertTenderEvaluationDto tenderEvaluation) : IRequest<TenderEvaluationDto>;

}
