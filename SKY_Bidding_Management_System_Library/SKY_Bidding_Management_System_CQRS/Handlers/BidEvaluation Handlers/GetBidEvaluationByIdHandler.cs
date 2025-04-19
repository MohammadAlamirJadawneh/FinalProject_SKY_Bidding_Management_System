using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidEvaluation_Handlers
{
    public record GetBidEvaluationByIdHandler(AppDbContext Db) : IRequestHandler<GetBidEvaluationByIdQuery, BidEvaluationDto>
    {
        public async Task<BidEvaluationDto> Handle(GetBidEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            var bidEvaluation = await Db.BidEvaluations
                .Where(te => te.BidEvaluationId == request.BidEvaluationId)
                .FirstOrDefaultAsync(cancellationToken);

            if (bidEvaluation == null)
            {
                Console.WriteLine($"BidEvaluation with ID {request.BidEvaluationId} not found.");
                return null;
            }

            return new BidEvaluationDto
            {
                BidEvaluationId = bidEvaluation.BidEvaluationId,
                BidId = bidEvaluation.BidId,
                BidEvaluationScore = bidEvaluation.BidEvaluationScore,
                EvaluatedAt = bidEvaluation.EvaluatedAt,
                BidEvaluationNotes = bidEvaluation.BidEvaluationNotes
            };
        }
    }
 
}
