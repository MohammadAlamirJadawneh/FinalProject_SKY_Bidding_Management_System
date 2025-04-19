using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;

namespace SKY_Bidding_Management_System_Library.Service.TenderAwardService
{
    public interface ITenderAwardService
    {
        Task<List<TenderAwardDto>> GetAllTenderAwardsAsync();
        Task<TenderAwardDto> GetTenderAwardByIdAsync(int id);
        Task<TenderAwardDto> InsertTenderAwardAsync(InsertTenderAwardDto dto);
        Task<TenderAwardDto> UpdateTenderAwardAsync(int id, UpdateTenderAwardCommand command);
        Task<bool> DeleteTenderAwardAsync(int id);
    }

}
