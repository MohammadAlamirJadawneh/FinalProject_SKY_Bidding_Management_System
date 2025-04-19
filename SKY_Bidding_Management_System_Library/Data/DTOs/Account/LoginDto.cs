using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
