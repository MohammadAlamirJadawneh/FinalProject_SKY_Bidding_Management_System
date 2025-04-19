using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderEvaluation_Queries
{
    public record GetTenderEvaluationByIdQuery(int TenderEvaluationId) : IRequest<TenderEvaluationDto>;

}
