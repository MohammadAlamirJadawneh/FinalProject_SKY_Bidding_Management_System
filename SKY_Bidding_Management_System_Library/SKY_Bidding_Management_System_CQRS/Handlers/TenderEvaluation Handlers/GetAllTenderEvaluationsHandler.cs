using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderEvaluationHandlers
{

    public class GetAllTenderEvaluationsHandler : IRequestHandler<GetAllTenderEvaluationsQuery, List<TenderEvaluationDto>>
    {
        private readonly AppDbContext _db;

        public GetAllTenderEvaluationsHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TenderEvaluationDto>> Handle(GetAllTenderEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var evaluations = await _db.TenderEvaluations
                .Select(te => new TenderEvaluationDto
                {
                    TenderEvaluationId = te.TenderEvaluationId,
                    TenderId = te.TenderId,
                    ScoreTenderEvaluation = te.ScoreTenderEvaluation,
                    TenderEvaluationNotes = te.TenderEvaluationNotes
                })
                .ToListAsync(cancellationToken);

            return evaluations;
        }
    }
}
