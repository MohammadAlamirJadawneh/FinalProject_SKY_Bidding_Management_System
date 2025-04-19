using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderCategoryService
{
    public interface ITenderCategoryService
    {
        public Task<List<TenderCategoryDto>> GetAllTenderCategoriesAsync();
        public Task<TenderCategoryDto> GetTenderCategoryByIdAsync(int tenderCategoryId);
        public Task<TenderCategoryDto> InsertTenderCategory(InsertTenderCategoryDto dto);
        public Task<TenderCategoryDto> UpdateTenderCategory(int id, UpdateTenderCategoryCommand command);
        public Task<bool> DeleteTenderCategoryById(int id);
    }
}
