namespace SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem
{
    public class FinancialProposalItemDto
    {
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public FinancialProposalItemDto(string itemDescription, int quantity, decimal unitPrice, decimal totalPrice)

        {
            ItemDescription = itemDescription;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;

        }
    }

}
