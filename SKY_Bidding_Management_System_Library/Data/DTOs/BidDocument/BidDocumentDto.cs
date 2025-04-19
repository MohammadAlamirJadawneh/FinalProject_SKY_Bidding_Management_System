namespace SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument
{
    public class BidDocumentDto
    {
        public int BidDocumentId { get; set; }
        public string BidDocumentName { get; set; }
        public string BidDocumentContentType { get; set; }
        public byte[]? BidDocumentData { get; set; } = null; 
        public DateTime BidDocumentUploadedDate { get; set; }

        public BidDocumentDto(int bidDocumentId, string bidDocumentName, string bidDocumentContentType, DateTime bidDocumentUploadedDate, byte[] bidDocumentData = null)
        {
            BidDocumentId = bidDocumentId;
            BidDocumentName = bidDocumentName;
            BidDocumentContentType = bidDocumentContentType;
            BidDocumentUploadedDate = bidDocumentUploadedDate;
            BidDocumentData = bidDocumentData;  
        }
    }






}
