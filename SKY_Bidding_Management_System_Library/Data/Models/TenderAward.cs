using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderAward
    {
        [Key]
        public int TenderAwardId { get; set; }
        [ForeignKey("Tender")]
        public int TenderId { get; set; }

        [ForeignKey("Bid")]
        public int BidId { get; set; }

        public DateTime AwardDate { get; set; }
        public string AwardStatus { get; set; }
        public virtual Tender Tender { get; set; }
        public virtual Bid Bid { get; set; }
    }
}
