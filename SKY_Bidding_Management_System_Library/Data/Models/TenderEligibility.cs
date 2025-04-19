using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderEligibility
    {
        [Key]
        public int TenderEligibilityId { get; set; }

        public int TenderId { get; set; }
        public bool IsRegisteredCompany { get; set; }
        public bool HasMinimumExperience { get; set; }
        public bool IsFinanciallyStable { get; set; }
        public bool HasPastExperience { get; set; }
        public bool CompliesWithIndustryStandards { get; set; }

         public virtual Tender Tender { get; set; }
    }

}
