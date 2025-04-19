using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{



    public class FinancialProposalItem
    {
        [Key]
        public int FinancialProposalItemId { get; set; }

        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;

        public int BidId { get; set; }   
        public virtual Bid Bid { get; set; }
    }
}
