using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidEvaluation_Handlers
{
    public record InsertBidEvaluationHandler(AppDbContext Db) : IRequestHandler<InsertBidEvaluationCommand, BidEvaluationDto>
    {
        public async Task<BidEvaluationDto> Handle(InsertBidEvaluationCommand request, CancellationToken cancellationToken)
        {
            var bidEvaluation = new BidEvaluation
            {
                BidId = request.BidEvaluation.BidId,
                BidEvaluationScore = request.BidEvaluation.BidEvaluationScore,
                BidEvaluationNotes = request.BidEvaluation.BidEvaluationNotes,
                EvaluatedAt = request.BidEvaluation.EvaluatedAt,
            };

            Db.BidEvaluations.Add(bidEvaluation);
            await Db.SaveChangesAsync(cancellationToken);

            return new BidEvaluationDto
            {
                BidEvaluationId = bidEvaluation.BidEvaluationId,
                BidId = bidEvaluation.BidId,
                BidEvaluationScore = bidEvaluation.BidEvaluationScore,
                BidEvaluationNotes = bidEvaluation.BidEvaluationNotes,
                EvaluatedAt = bidEvaluation.EvaluatedAt,
            };
        }
    }
     
}
