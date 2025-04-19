using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderEvaluation
    {
        [Key]
        public int TenderEvaluationId { get; set; }
        [ForeignKey("Tender")]
        public int TenderId { get; set; }
        public decimal ScoreTenderEvaluation { get; set; }
        public string TenderEvaluationNotes { get; set; }

        public virtual Tender Tender { get; set; }
    }
}
