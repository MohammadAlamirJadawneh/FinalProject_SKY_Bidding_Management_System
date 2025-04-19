using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{

    public static class TenderScopeDocumentTemplateGenerator
    {
        public static string GenerateTenderScopeText(TenderScopeDto tenderScope)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Tender Scope Overview");
            sb.AppendLine("---------------------");
            sb.AppendLine($"Project Description: {tenderScope.ProjectDescription}");
            sb.AppendLine("\nDeliverables:");

            foreach (var deliverable in tenderScope.Deliverables)
            {
                sb.AppendLine($"- {deliverable}");
            }

            sb.AppendLine("\nExpected Timeline:");

            foreach (var timelineItem in tenderScope.ExpectedTimeline)
            {
                sb.AppendLine($"{timelineItem.Activity}: {timelineItem.ExpectedDate:dd/MM/yyyy}");
            }

            return sb.ToString();
        }
    }

}
