using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderEvaluationHandlers
{


    public record UpdateTenderEvaluationHandler : IRequestHandler<UpdateTenderEvaluationCommand, TenderEvaluationDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderEvaluationHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TenderEvaluationDto> Handle(UpdateTenderEvaluationCommand request, CancellationToken cancellationToken)
        {
             


            var tenderEvaluation = await _db.TenderEvaluations.FindAsync(request.TenderEvaluationId);

            if (tenderEvaluation == null)
            {
                Console.WriteLine("TenderEvaluation not found.");
                return null;
            }

             tenderEvaluation.TenderId = request.TenderId;
            tenderEvaluation.ScoreTenderEvaluation = request.ScoreTenderEvaluation;
            tenderEvaluation.TenderEvaluationNotes = request.TenderEvaluationNotes;

             await _db.SaveChangesAsync(cancellationToken);

             return new TenderEvaluationDto
            {
                TenderEvaluationId = tenderEvaluation.TenderEvaluationId,
                TenderId = tenderEvaluation.TenderId,
                ScoreTenderEvaluation = tenderEvaluation.ScoreTenderEvaluation,
                TenderEvaluationNotes = tenderEvaluation.TenderEvaluationNotes
            };
        }
    }
}
