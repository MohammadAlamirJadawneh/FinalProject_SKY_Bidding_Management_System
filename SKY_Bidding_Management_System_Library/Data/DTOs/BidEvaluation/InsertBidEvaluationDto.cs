namespace SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation
{
    public class InsertBidEvaluationDto
    {

        public int BidId { get; set; }

        public decimal BidEvaluationScore { get; set; }
        public string BidEvaluationNotes { get; set; }
        public DateTime EvaluatedAt { get; set; }
    }
}
