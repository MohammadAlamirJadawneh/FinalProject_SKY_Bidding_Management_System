using Microsoft.AspNetCore.Http;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument
{
    public class InsertTenderDocumentDto
    {
        public IFormFile TenderDocumentFile { get; set; }
        public int TenderId { get; set; }
    }


}
