namespace SKY_Bidding_Management_System_Library.Data.DTOs.Bid
{
    public class BidderInformationDto
    {
        public int BidId { get; set; }

        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }





      
        public BidderInformationDto()
        {

        }
        public BidderInformationDto(string companyName, string registrationNumber, string address, string email, string phone)
        {
            CompanyName = companyName;
            RegistrationNumber = registrationNumber;
            Address = address;
            Email = email;
            Phone = phone;

        }
    }
}
