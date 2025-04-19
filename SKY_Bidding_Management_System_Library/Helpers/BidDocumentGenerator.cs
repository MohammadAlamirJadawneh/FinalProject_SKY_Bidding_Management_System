
namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class BidDocumentGenerator
    {
        public static string GenerateBidSubmissionText(int bidId, string companyName, string registrationNumber, string address, string email, string phone)
        {
          
            var bidderInfo = $@"
Bid Submission Document
=======================================

Company Name:          {companyName}
Registration Number:   {registrationNumber}
Address:               {address}
Email:                 {email}
Phone:                 {phone}

 ";

            
            return bidderInfo;
        }
    }


}
