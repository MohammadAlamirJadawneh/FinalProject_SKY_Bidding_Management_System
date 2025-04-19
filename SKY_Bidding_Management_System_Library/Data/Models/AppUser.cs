using Microsoft.AspNetCore.Identity;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class AppUser : IdentityUser
    //public class AppUser : IdentityUser<int>
    {

    }

    public class SmtpSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string From { get; set; } = default!;
    }

}
