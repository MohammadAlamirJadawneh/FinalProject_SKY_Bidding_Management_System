using MediatR;
using Microsoft.AspNetCore.Identity;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.AccountService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Account_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Account_Handlers
{
    public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommand, IdentityResult>
    {
        private readonly IAccountService _accountService;

        public PasswordResetCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IdentityResult> Handle(PasswordResetCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.ResetPasswordAsync(request.ResetDto);
        }
    }





}
