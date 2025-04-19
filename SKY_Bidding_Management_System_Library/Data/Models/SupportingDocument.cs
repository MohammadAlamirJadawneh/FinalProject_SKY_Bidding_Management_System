using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class SupportingDocument
    {
        [Key]
        public int SupportingDocumentId { get; set; }
        public int BidId { get; set; }  
        public string DocumentName { get; set; }
        public string Description { get; set; }
 
        public virtual Bid Bid { get; set; }
    }

}
