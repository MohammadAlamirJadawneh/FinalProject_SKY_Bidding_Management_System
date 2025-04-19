using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory
{

    public class TenderCategoryDto
    {
        public int TenderCategoryId { get; set; }
        [Required]
        public string TenderCategoryName { get; set; }
    }
}
