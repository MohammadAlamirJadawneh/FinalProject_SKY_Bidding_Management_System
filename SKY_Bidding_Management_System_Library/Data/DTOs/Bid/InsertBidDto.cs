using Microsoft.AspNetCore.Http;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.Bid
{
    public class InsertBidDto
    {
        public int TenderId { get; set; }
        public int BidderId { get; set; }
        public DateOnly SubmissionDate { get; set; }

    
        public List<IFormFile> BidDocuments { get; set; }
    }


}
