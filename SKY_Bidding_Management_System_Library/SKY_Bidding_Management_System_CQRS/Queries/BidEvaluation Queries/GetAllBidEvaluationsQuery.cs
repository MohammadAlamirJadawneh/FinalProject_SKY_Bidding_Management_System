using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidEvaluation_Queries
{

    public record GetAllBidEvaluationsQuery() : IRequest<List<BidEvaluationDto>>;
}
