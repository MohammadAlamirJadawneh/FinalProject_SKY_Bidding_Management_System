using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidEvaluation_Handlers
{
    public record GetAllBidEvaluationsHandler(AppDbContext Db) : IRequestHandler<GetAllBidEvaluationsQuery, List<BidEvaluationDto>>
    {
        public async Task<List<BidEvaluationDto>> Handle(GetAllBidEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var evaluations = await Db.BidEvaluations
                .Select(te => new BidEvaluationDto
                {
                    BidEvaluationId = te.BidEvaluationId,
                    BidId = te.BidId,
                    BidEvaluationNotes = te.BidEvaluationNotes,
                    BidEvaluationScore = te.BidEvaluationScore,
                    EvaluatedAt = te.EvaluatedAt,
                })
                .ToListAsync(cancellationToken);

            return evaluations;
        }
    }

    
}
