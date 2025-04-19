using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class BidProposalGenerator
    {
        public static string GenerateBidProposalText(BidProposalDto bidProposal)
        {
            var sb = new StringBuilder();

           
            sb.AppendLine("Technical Proposal Summary")
              .AppendLine("=======================================")
              .AppendLine(bidProposal.TechnicalSummary)
              .AppendLine()
              .AppendLine("Financial Proposal")
              .AppendLine("=======================================")
              .AppendLine("Item Description      Quantity    Unit Price    Total Price")
              .AppendLine("------------------------------------------------------------");

            
            foreach (var item in bidProposal.FinancialProposalItems)
            {
                sb.AppendLine($"{item.ItemDescription,-20} {item.Quantity,-10} {item.UnitPrice:C,-12} {item.TotalPrice:C}");
            }

         
            var totalBidAmount = bidProposal.FinancialProposalItems.Sum(i => i.TotalPrice);
            sb.AppendLine("------------------------------------------------------------")
              .AppendLine($"Total Bid Amount: {totalBidAmount:C}")
              .AppendLine();

            return sb.ToString();
        }
    }

}
