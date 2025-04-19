using MediatR;
using Microsoft.AspNetCore.Identity;
using SKY_Bidding_Management_System_Library.Data.DTOs.Account;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Account_Commands
{
    //public record PasswordResetCommand(string Email, string PhoneNumber, string NewPassword) : IRequest<IdentityResult>;
    public record PasswordResetCommand(ResetPasswordDto ResetDto) : IRequest<IdentityResult>;





}
