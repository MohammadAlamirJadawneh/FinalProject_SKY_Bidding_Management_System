using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.Tender
{
    public class TenderDto
    {
        public int TenderId { get; set; }

        public string TenderIssuedBy { get; set; }
        public string TenderTitle { get; set; }
        public string TenderDescription { get; set; }
        public decimal TenderBudget { get; set; }

        public DateTime TenderIssueDate { get; set; }
        public DateTime TenderClosingDate { get; set; }
        public TenderStatusEnum TenderStatus { get; set; }
        public string Email { get; set; }
        public string EligibilityCriteria { get; set; }

        public int CategoryId { get; set; }
        public int IndustryId { get; set; }
        public int TenderTypeId { get; set; }
        public int LocationId { get; set; }
        public List<TenderDocumentDto>? TenderDocuments { get; set; }
 
        public string? TenderCategoryName { get; set; }
        public string? TenderIndustryName { get; set; }
        public string? TenderTypeName { get; set; }
        public string? TenderLocationName { get; set; }
         

    }

}
