using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidEvaluation_Handlers
{



    public record DeleteBidEvaluationHandler : IRequestHandler<DeleteBidEvaluationCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteBidEvaluationHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteBidEvaluationCommand request, CancellationToken cancellationToken)
        {
            var BidEvaluation = await _db.BidEvaluations.FindAsync(request.BidEvaluationId);

            if (BidEvaluation == null)
            {
                Console.WriteLine($"BidEvaluation with ID {request.BidEvaluationId} not found.");
                return false;
            }

            _db.BidEvaluations.Remove(BidEvaluation);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
