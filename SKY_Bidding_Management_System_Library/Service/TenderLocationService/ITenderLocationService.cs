using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderLocationService
{
    public interface ITenderLocationService
    {
        public Task<List<TenderLocationDto>> GetAllTenderLocationsAsync();
        public Task<TenderLocationDto> GetTenderLocationByIdAsync(int tenderLocationId);
        public Task<TenderLocationDto> InsertTenderLocation(InsertTenderLocationDto dto);

        public Task<TenderLocationDto> UpdateTenderLocation(int id, UpdateTenderLocationCommand command);
        public Task<bool> DeleteTenderLocationById(int id);
    }
}
