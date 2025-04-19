using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory
{
    public class InsertTenderCategoryDto
    {
        [Required]
        public string TenderCategoryName { get; set; }
    }
}
