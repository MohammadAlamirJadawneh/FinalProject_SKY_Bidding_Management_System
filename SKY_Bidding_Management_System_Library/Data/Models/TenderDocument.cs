using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderDocument
    {
        [Key]
        public int TenderDocumentId { get; set; }

        public string TenderDocumentName { get; set; }
        public byte[]? TenderDocumentData { get; set; } = null;
        public string TenderDocumentContentType { get; set; } 
        public DateTime TenderDocumentUploadedDate { get; set; }
        public string? DocumentContent { get; set; }
        [ForeignKey("Tender")]
        public int TenderId { get; set; }
        public virtual Tender Tender { get; set; }




    }
}
