using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation
{
    public class TenderLocationDto
    {
        public int TenderLocationId { get; set; }
        [Required]
        public string TenderLocationName { get; set; }

    }
}
