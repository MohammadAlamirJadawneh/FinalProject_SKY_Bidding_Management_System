using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Tenderding_Management_System_Library.Service.TenderDocumentService
{
    public interface ITenderDocumentService
    {
        Task<TenderDocumentDto> InsertTenderDocumentAsync(IFormFile file, int TenderId);

        Task<List<TenderDocumentDto>> GetAllTenderDocumentsAsync();
        Task<TenderDocumentDto> UpdateTenderDocumentAsync(UpdateTenderDocumentDto command);
        Task<bool> DeleteTenderDocumentAsync(int id);
        Task<FileContentResult?> DownloadTenderDocumentsAsZipAsync(int tenderDocumentId);

    }
}
