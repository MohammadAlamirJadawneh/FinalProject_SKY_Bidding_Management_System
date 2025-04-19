using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{


    public class Bid
    {
        [Key]

        public int BidId { get; set; }

        public string? CompanyName { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }


        [ForeignKey("Tender")]
        public int TenderId { get; set; }


        public string? BidderId { get; set; }  
        public DateTime SubmissionDate { get; set; }

        public virtual ICollection<FinancialProposalItem>? FinancialProposalItems { get; set; }  
        public string? TechnicalSummary { get; set; }
         
        public virtual AppUser? Bidder { get; set; }  
        public virtual Tender? Tender { get; set; }
        public virtual ICollection<BidDocument>? BidDocument { get; set; }

    }
}
