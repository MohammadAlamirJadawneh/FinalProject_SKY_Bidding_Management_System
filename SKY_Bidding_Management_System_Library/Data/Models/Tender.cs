using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 namespace SKY_Bidding_Management_System_Library.Data.Models
{



    public class Tender
    {
        [Key]
        public int TenderId { get; set; }
        [ForeignKey("TenderUser")]
        
        public string? TenderIssuedBy { get; set; }
        public string TenderTitle { get; set; }
        public string TenderDescription { get; set; }
        public decimal TenderBudget { get; set; }

        public DateTime TenderIssueDate { get; set; }
        public DateTime TenderClosingDate { get; set; }
        public TenderStatusEnum TenderStatus { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string EligibilityCriteria { get; set; }

        [ForeignKey("TenderCategory")]
        public int CategoryId { get; set; }


        [ForeignKey("TenderIndustry")]
        public int IndustryId { get; set; }

        [ForeignKey("TenderType")]
        public int TenderTypeId { get; set; }

        [ForeignKey("TenderLocation")]
        public int LocationId { get; set; }

        public virtual AppUser TenderUser { get; set; }

        public virtual TenderIndustry? TenderIndustry { get; set; }
        public virtual TenderCategory? TenderCategory { get; set; }
        public virtual TenderType? TenderType { get; set; }
        public virtual TenderLocation? TenderLocation { get; set; }
        public virtual ICollection<TenderDocument>? TenderDocument { get; set; }
        public virtual ICollection<TenderEvaluation>? TenderEvaluations { get; set; }
        public virtual ICollection<SubmissionGuideline>? SubmissionGuidelines { get; set; }

    }


}
