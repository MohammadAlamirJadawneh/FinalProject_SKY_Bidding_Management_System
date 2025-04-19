using SKY_Bidding_Management_System_Library.Data.DTOs.SupportingDocumentsText;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class SupportingDocumentGenerator
    {
        public static string GenerateSupportingDocumentsText(List<SupportingDocumentDto> supportingDocuments)
        {
            var textBuilder = new StringBuilder();
            textBuilder.AppendLine("Supporting Documents");
            textBuilder.AppendLine("The following documents are attached to support this bid:");

            foreach (var doc in supportingDocuments)
            {
                textBuilder.AppendLine($"✅ {doc.DocumentName}: {doc.Description}");
            }

            return textBuilder.ToString();
        }
    }


}
