using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class SubmissionGuideline
    {
        [Key]
        public int SubmissionGuidelineId { get; set; }
        public int TenderId { get; set; }
        public string? RequiredDocument { get; set; }
        public string? TechnicalProposal { get; set; }   
        public string? FinancialProposal { get; set; }   
        public string? CompanyProfile { get; set; }   

    
        public virtual Tender? Tender { get; set; }
    }


}
