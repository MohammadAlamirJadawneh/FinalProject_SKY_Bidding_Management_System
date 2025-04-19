using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class BidEvaluation
    {
        [Key]
        public int BidEvaluationId { get; set; }

        [ForeignKey("Bid")]
        public int BidId { get; set; }

        public decimal BidEvaluationScore { get; set; }
        public string BidEvaluationNotes { get; set; }
        public DateTime EvaluatedAt { get; set; }
        public virtual Bid Bid { get; set; }
    }
}
