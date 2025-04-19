using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class DeclarationTextGenerator
    {
        public static string GenerateDeclarationText(DeclarationDto declarationDto)
        {
            var declarationText = new StringBuilder();

            declarationText.AppendLine($"We, {declarationDto.CompanyName}, hereby submit this bid in response to the above-mentioned tender.");
            declarationText.AppendLine("We confirm that:");
            declarationText.AppendLine("• All provided information is accurate and complete.");
            declarationText.AppendLine("• We comply with all tender requirements.");
            declarationText.AppendLine("• We understand and accept the terms and conditions set forth in the tender document.");
            declarationText.AppendLine($"Authorized Signatory: {declarationDto.AuthorizedSignatory}");
            declarationText.AppendLine($"Date: {declarationDto.SubmissionDate.ToString("dd/MM/yyyy")}");

            return declarationText.ToString();
        }
    }


}
