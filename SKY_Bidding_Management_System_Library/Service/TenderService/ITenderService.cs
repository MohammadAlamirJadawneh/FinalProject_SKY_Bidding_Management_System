using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.EligibilityCriteriaCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;

namespace SKY_Bidding_Management_System_Library.Service.TenderService
{
    public interface ITenderService
    {
        Task<TenderDto> GetTenderByIdAsync(int tenderId);
        Task<List<TenderDto>> GetAllTendersAsync();
        Task<TenderDto> InsertTenderAsync(InsertTenderCommand command);
        Task<TenderDto> UpdateTenderAsync(UpdateTenderCommand command);
        Task<bool> DeleteTenderAsync(int tenderId);
        Task<IEnumerable<TenderDto>> GetOpenTendersAsync();
        Task<FileContentResult?> DownloadTenderDocumentsAsZipAsync(int tenderId);
        Task<string> GenerateTenderOverviewAsync(int tenderId);

        Task<TenderScopeDto> GetTenderScopeAsync(int tenderId);
        Task SetEligibilityCriteriaAsync(SetEligibilityCriteriaCommand command);
        Task<EligibilityCriteriaDto> GetEligibilityCriteriaAsync(int tenderId);
        Task<byte[]> GenerateTenderContactInfoAsync(int tenderId);
        Task RefreshTenderStatusesAsync(CancellationToken cancellationToken);

    }

}
