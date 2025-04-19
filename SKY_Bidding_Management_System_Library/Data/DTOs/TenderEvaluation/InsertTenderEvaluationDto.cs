namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation
{
    public class InsertTenderEvaluationDto
    {
        public int TenderId { get; set; }    
        public decimal ScoreTenderEvaluation { get; set; }
        public string TenderEvaluationNotes { get; set; }
    }
}
