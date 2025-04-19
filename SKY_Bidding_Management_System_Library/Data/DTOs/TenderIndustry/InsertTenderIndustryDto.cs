using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry
{
    public class InsertTenderIndustryDto
    {
        [Required]
        public string TenderIndustryName { get; set; }
    }
}
