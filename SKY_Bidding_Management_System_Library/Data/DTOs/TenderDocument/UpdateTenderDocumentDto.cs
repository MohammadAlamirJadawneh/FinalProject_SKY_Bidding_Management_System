using Microsoft.AspNetCore.Http;

namespace SKY_Tenderding_Management_System_Library.Data.DTOs.TenderDocument
{
    public class UpdateTenderDocumentDto
    {

        public int TenderDocumentId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public IFormFile TenderDocumentFile { get; set; }
    }

}
