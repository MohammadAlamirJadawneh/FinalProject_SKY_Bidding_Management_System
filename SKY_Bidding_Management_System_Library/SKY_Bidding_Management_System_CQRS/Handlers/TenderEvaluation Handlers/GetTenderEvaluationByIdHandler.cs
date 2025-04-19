using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderEvaluationHandlers
{


    public class GetTenderEvaluationByIdHandler : IRequestHandler<GetTenderEvaluationByIdQuery, TenderEvaluationDto>
    {
        private readonly AppDbContext _db;

        public GetTenderEvaluationByIdHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TenderEvaluationDto> Handle(GetTenderEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderEvaluation = await _db.TenderEvaluations
                .Where(te => te.TenderEvaluationId == request.TenderEvaluationId)
                .FirstOrDefaultAsync(cancellationToken);


            if (tenderEvaluation == null)
            {
                Console.WriteLine($"tenderEvaluation with ID {request.TenderEvaluationId} not found.");
                return null;
            }

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
