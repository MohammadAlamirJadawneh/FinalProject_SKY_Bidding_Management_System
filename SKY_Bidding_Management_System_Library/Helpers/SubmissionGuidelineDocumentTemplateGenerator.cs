using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{

    public static class SubmissionGuidelineDocumentTemplateGenerator
    {
        public static string GenerateSubmissionGuidelineText(SubmissionGuidelineDto submissionGuideline)
        {
            if (submissionGuideline == null)
                return string.Empty;

            var builder = new StringBuilder();
            builder.AppendLine($"Tender ID: {submissionGuideline.TenderId}");
            builder.AppendLine($"Technical Proposal: {submissionGuideline.TechnicalProposal}");
            builder.AppendLine($"Financial Proposal: {submissionGuideline.FinancialProposal}");
            builder.AppendLine($"Company Profile: {submissionGuideline.CompanyProfile}");

            return builder.ToString();
        }
    }


}



