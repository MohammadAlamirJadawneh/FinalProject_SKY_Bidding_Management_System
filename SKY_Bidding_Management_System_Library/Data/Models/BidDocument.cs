using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class BidDocument
    {
        [Key]
        public int BidDocumentId { get; set; }

        public string BidDocumentName { get; set; }
        public string BidDocumentContentType { get; set; }
        public byte[]? BidDocumentData { get; set; } = null;
        public DateTime BidDocumentUploadedDate { get; set; }   

        [ForeignKey("Bid")]
        public int BidId { get; set; }
        public virtual Bid? Bid { get; set; }
    }



}
