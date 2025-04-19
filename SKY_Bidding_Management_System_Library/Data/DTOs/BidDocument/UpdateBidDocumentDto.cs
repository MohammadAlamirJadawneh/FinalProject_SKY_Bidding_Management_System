using Microsoft.AspNetCore.Http;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument
{
    public class UpdateBidDocumentDto
    {
        public int BidDocumentId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public IFormFile BidDocumentFile { get; set; }
    }




}
