using SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class EligibilityCriteriaDocumentTemplateGenerator
    {
        public static string GenerateEligibilityCriteriaText(EligibilityCriteriaDto eligibility)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Tender Eligibility Criteria");
            sb.AppendLine("----------------------------");
            sb.AppendLine("Bidders must meet the following criteria:");
            sb.AppendLine($"1. Registered Company: {(eligibility.IsRegisteredCompany ? "Yes" : "No")}");
            sb.AppendLine($"2. Minimum Experience: {(eligibility.HasMinimumExperience ? "Yes" : "No")}");
            sb.AppendLine($"3. Financial Stability: {(eligibility.IsFinanciallyStable ? "Yes" : "No")}");
            sb.AppendLine($"4. Past Experience: {(eligibility.HasPastExperience ? "Yes" : "No")}");
            sb.AppendLine($"5. Compliance with Industry Standards: {(eligibility.CompliesWithIndustryStandards ? "Yes" : "No")}");

            return sb.ToString();
        }
    }

}
