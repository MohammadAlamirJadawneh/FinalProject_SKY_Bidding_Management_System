using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;

namespace SKY_Bidding_Management_System_Library.Helpers
{

    public static class TenderContactInformationGenerator
    {
        public static string GenerateContactInfoText(TenderDto tender)
        {
           
            var contactInfo = $@"  

Contact Information:
=======================================



For any queries regarding this tender, contact:

Email: {tender.Email}
";

             
            var documentContent = $@"
Tender Document for Tender ID: {tender.TenderId}
-----------------------------------------------
{contactInfo}
";

            return documentContent;
        }
    }




}
