using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidEvaluation_Handlers
{

    public record UpdateBidEvaluationHandler : IRequestHandler<UpdateBidEvaluationCommand, BidEvaluationDto>
    {
        private readonly AppDbContext _db;

        public UpdateBidEvaluationHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<BidEvaluationDto> Handle(UpdateBidEvaluationCommand request, CancellationToken cancellationToken)
        {

 



            var BidEvaluation = await _db.BidEvaluations.FindAsync(request.BidEvaluationId);

            if (BidEvaluation == null)
            {
                Console.WriteLine("BidEvaluation not found.");
                return null;
            }

            
            BidEvaluation.BidEvaluationId = request.BidEvaluationId;

            BidEvaluation.BidId = request.BidId;
            BidEvaluation.BidEvaluationScore = request.BidEvaluationScore;
            BidEvaluation.BidEvaluationNotes = request.BidEvaluationNotes;
            BidEvaluation.EvaluatedAt = request.EvaluatedAt;
         
            await _db.SaveChangesAsync(cancellationToken);

            
            return new BidEvaluationDto
            {
                BidEvaluationId = BidEvaluation.BidEvaluationId,
                BidId = BidEvaluation.BidId,
                BidEvaluationScore = BidEvaluation.BidEvaluationScore,
                BidEvaluationNotes = BidEvaluation.BidEvaluationNotes,
                EvaluatedAt = BidEvaluation.EvaluatedAt
            };
        }
    }
}
