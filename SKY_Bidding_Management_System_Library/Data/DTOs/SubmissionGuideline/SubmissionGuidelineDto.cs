namespace SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline
{
    public class SubmissionGuidelineDto
    {
        public int TenderId { get; set; }
        public string RequiredDocument { get; set; }

        public string? TechnicalProposal { get; set; }
        public string? FinancialProposal { get; set; }
        public string? CompanyProfile { get; set; }
    }

}
