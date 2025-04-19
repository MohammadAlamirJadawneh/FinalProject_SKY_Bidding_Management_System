using Microsoft.AspNetCore.Http;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument
{
    public class InsertBidDocumentDto
    {
        public IFormFile BidDocumentFile { get; set; }
        public int BidId { get; set; }
    }




}
