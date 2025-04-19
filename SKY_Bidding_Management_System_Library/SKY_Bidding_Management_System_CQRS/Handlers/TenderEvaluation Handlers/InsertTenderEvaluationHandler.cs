using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderEvaluationHandlers
{
    public record InsertTenderEvaluationHandler(AppDbContext Db) : IRequestHandler<InsertTenderEvaluationCommand, TenderEvaluationDto>
    {
        public async Task<TenderEvaluationDto> Handle(InsertTenderEvaluationCommand request, CancellationToken cancellationToken)
        {
            var tenderEvaluation = new TenderEvaluation
            {
                TenderId = request.tenderEvaluation.TenderId,
                ScoreTenderEvaluation = request.tenderEvaluation.ScoreTenderEvaluation,
                TenderEvaluationNotes = request.tenderEvaluation.TenderEvaluationNotes
            };

            Db.TenderEvaluations.Add(tenderEvaluation);
            await Db.SaveChangesAsync(cancellationToken);

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
