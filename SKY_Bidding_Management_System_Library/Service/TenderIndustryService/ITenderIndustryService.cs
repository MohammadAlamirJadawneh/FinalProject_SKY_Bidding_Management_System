using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderIndustryService
{

    public interface ITenderIndustryService
    {
        public Task<List<TenderIndustryDto>> GetAllTenderIndustrysAsync();
        public Task<TenderIndustryDto> GetTenderIndustryByIdAsync(int tenderIndustryId);
        Task<TenderIndustryDto> InsertTenderIndustry(InsertTenderIndustryDto dto);

        public Task<TenderIndustryDto> UpdateTenderIndustry(int id, UpdateTenderIndustryCommand command);
        public Task<bool> DeleteTenderIndustryById(int id);
    }
}
