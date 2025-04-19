using Microsoft.AspNetCore.Identity;
using SKY_Bidding_Management_System_Library.Data.DTOs.Account;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Account_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKY_Bidding_Management_System_Library.Service.AccountService
{
   public interface IAccountService
    {
 
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto dto);
        string Logout();
    }
}
