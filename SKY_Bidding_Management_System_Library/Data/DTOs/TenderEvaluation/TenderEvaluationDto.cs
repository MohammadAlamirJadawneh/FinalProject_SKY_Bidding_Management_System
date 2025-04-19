namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation
{
    public class TenderEvaluationDto
    {
        public int TenderEvaluationId { get; set; }
        public int TenderId { get; set; }
        public decimal ScoreTenderEvaluation { get; set; }
        public string TenderEvaluationNotes { get; set; }
    }
}
