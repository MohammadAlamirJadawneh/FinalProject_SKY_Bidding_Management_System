using Microsoft.AspNetCore.Identity;
using SKY_Bidding_Management_System_Library.Data.DTOs.Account;
using SKY_Bidding_Management_System_Library.Data.Models;
namespace SKY_Bidding_Management_System_Library.Service.AccountService
{
    public class AccountService : IAccountService
    {
 
        private readonly UserManager<AppUser> _userManager;

        public AccountService(UserManager<AppUser> userManager )
        {
            _userManager = userManager;
        }


        
        public string Logout()
        {
             
            return "Logged out successfully. Please remove the token on the client side.";
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
        }
    }
}
