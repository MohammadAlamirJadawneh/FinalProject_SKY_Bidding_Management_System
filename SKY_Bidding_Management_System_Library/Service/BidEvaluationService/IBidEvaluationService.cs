using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;

namespace SKY_Bidding_Management_System_Library.Service.BidEvaluationService
{
    public interface IBidEvaluationService
    {
        public Task<List<BidEvaluationDto>> GetAllBidEvaluationsAsync();
        public Task<BidEvaluationDto> GetBidEvaluationByIdAsync(int BidEvaluationId);
        public Task<BidEvaluationDto> InsertBidEvaluation(InsertBidEvaluationDto dto);

        public Task<BidEvaluationDto> UpdateBidEvaluation(int id, UpdateBidEvaluationCommand command);
        public Task<bool> DeleteBidEvaluationById(int id);
    }
}
