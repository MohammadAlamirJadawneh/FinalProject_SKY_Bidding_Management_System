using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;

namespace SKY_Bidding_Management_System_Library.Service.BidDocumentService
{
    public interface IBidDocumentService
    {
        Task<BidDocumentDto> InsertBidDocumentAsync(IFormFile file, int bidId);
        Task<List<BidDocumentDto>> GetAllBidDocumentsAsync();
        Task<BidDocumentDto> UpdateBidDocumentAsync(UpdateBidDocumentDto command);
        Task<bool> DeleteBidDocumentAsync(int id);
        Task<FileContentResult?> DownloadBidDocumentsAsZipAsync(int BidDocumentId);

    }


}
