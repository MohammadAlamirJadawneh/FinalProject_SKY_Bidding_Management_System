using SKY_Bidding_Management_System_Library.Data.Models;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class TenderDocumentTemplateGenerator
    {
        public static string GenerateTenderDocumentText(Tender tender)
        {
            return $@"
Tender Overview
=======================================
Tender Id: {tender.TenderTitle}

Tender Title: {tender.TenderTitle}

Tender Reference Number: TDR-{tender.TenderId:D5}

Issued By: {(string.IsNullOrWhiteSpace(tender.TenderIssuedBy) ? "N/A" : tender.TenderIssuedBy)}

Issue Date: {tender.TenderIssueDate:dd/MM/yyyy}

Closing Date: {tender.TenderClosingDate:dd/MM/yyyy}

Tender Type: {tender.TenderType?.TenderTypeName ?? "N/A"}

Tender Category: {tender.TenderCategory?.TenderCategoryName ?? "N/A"}

Budget Range: {(tender.TenderBudget > 0 ? $"{tender.TenderBudget:C}" : "Not Specified")}

Contact Email: {tender.Email}
";
        }
    }


}
