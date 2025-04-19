namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward
{
    public class TenderAwardDto
    {
        public int TenderAwardId { get; set; }
        public int TenderId { get; set; }
        public int BidId { get; set; }
        public DateTime AwardDate { get; set; }
        public string AwardStatus { get; set; }
    }
}
