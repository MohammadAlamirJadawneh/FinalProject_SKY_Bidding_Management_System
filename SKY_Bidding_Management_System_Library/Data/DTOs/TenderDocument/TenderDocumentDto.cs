namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument
{
    public class TenderDocumentDto
    {
        public int TenderDocumentId { get; set; }
        public string TenderDocumentName { get; set; }
        public string TenderDocumentContentType { get; set; }   
        public string TenderDocumentContent { get; set; }

        public int TenderId { get; set; }
        public byte[]? TenderDocumentData { get; set; } = null;
        public DateTime TenderDocumentUploadedDate { get; set; }

        public TenderDocumentDto() { }
        public TenderDocumentDto(int tenderDocumentId, string tenderDocumentName, string tenderDocumentContentType, DateTime tenderDocumentUploadedDate, byte[] tenderDocumentData = null)
        {
            TenderDocumentId = tenderDocumentId;
            TenderDocumentName = tenderDocumentName;
            TenderDocumentContentType = tenderDocumentContentType;
            TenderDocumentUploadedDate = tenderDocumentUploadedDate;
        }
    }

}
