using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderEvaluationService
{
    public interface ITenderEvaluationService
    {
        public Task<List<TenderEvaluationDto>> GetAllTenderEvaluationsAsync();
        public Task<TenderEvaluationDto> GetTenderEvaluationByIdAsync(int tenderEvaluationId);
        public Task<TenderEvaluationDto> InsertTenderEvaluation(InsertTenderEvaluationDto dto);

        public Task<TenderEvaluationDto> UpdateTenderEvaluation(int id, UpdateTenderEvaluationCommand command);
        public Task<bool> DeleteTenderEvaluationById(int id);
    }
}
