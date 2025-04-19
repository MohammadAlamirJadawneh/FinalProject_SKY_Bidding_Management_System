using SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.Bid
{
    public class BidProposalDto
    {
        public int BidId { get; set; }
        public string TechnicalSummary { get; set; }
        public List<FinancialProposalItemDto> FinancialProposalItems { get; set; }
    }
}
