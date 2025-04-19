using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderEvaluationHandlers
{


    public record DeleteTenderEvaluationHandler : IRequestHandler<DeleteTenderEvaluationCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteTenderEvaluationHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteTenderEvaluationCommand request, CancellationToken cancellationToken)
        {
            var tenderEvaluation = await _db.TenderEvaluations.FindAsync(request.TenderEvaluationId);

            if (tenderEvaluation == null)
            {
                Console.WriteLine($"tenderEvaluation with ID {request.TenderEvaluationId} not found.");
                return false;
            }

            _db.TenderEvaluations.Remove(tenderEvaluation);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
