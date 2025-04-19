using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderTypeService
{
    public interface ITenderTypeService
    {
        public Task<List<TenderTypeDto>> GetAllTenderTypesAsync();
        public Task<TenderTypeDto> GetTenderTypeByIdAsync(int tenderTypeId);
        public Task<TenderTypeDto> InsertTenderType(InsertTenderTypeDto dto);

        public Task<TenderTypeDto> UpdateTenderType(int id, UpdateTenderTypeCommand command);
        public Task<bool> DeleteTenderTypeById(int id);
    }
}
