using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.Bid
{
    public class BidDto
    {
        public int BidId { get; set; }
        public int TenderId { get; set; }
        public string BidderId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public List<BidDocumentDto>? BidDocuments { get; set; } = new();

        public string? TechnicalSummary { get; set; }
        public List<FinancialProposalItemDto>? FinancialProposalItems { get; set; }
        public string? CompanyName { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public BidDto(int bidId, int tenderId, string bidderId, DateTime submissionDate, List<BidDocumentDto> bidDocuments)
        {
            BidId = bidId;
            TenderId = tenderId;
            BidderId = bidderId;
            SubmissionDate = submissionDate;
            BidDocuments = bidDocuments;
        }
        public BidDto(int bidId, int tenderId, string bidderId, DateTime submissionDate, List<BidDocumentDto> bidDocuments, string technicalSummary,
             List<FinancialProposalItemDto>? financialProposalItems, string? companyName, string? registrationNumber, string? address, string? email, string? phone)
        {
            BidId = bidId;
            TenderId = tenderId;
            BidderId = bidderId;
            SubmissionDate = submissionDate;
            BidDocuments = bidDocuments;
            TechnicalSummary = technicalSummary;
            FinancialProposalItems = FinancialProposalItems;
            CompanyName = CompanyName;
            RegistrationNumber = registrationNumber;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }


}
