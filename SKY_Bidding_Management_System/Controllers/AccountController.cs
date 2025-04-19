using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.Account;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Account_Commands;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SKY_Bidding_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<AppUser> userManager, IConfiguration configuration, IMediator mediator)
        {
            _userManager = userManager;
            this.configuration = configuration;
            _mediator = mediator;
        }
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMediator _mediator;

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser(dtoNewUser user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    EmailConfirmed = true,

                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                await _userManager.AddToRoleAsync(appUser, ClsRoles.roleUser);

                if (result.Succeeded)
                {

                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }

            }
            return BadRequest();
        }

        [HttpPost]

        public async Task<IActionResult> LogIn(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, login.Password))
                    {

                        var userRoles = await _userManager.GetRolesAsync(user);


                        var claims = new List<Claim>();


                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        //claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);

                        foreach (var role in roles)
                        {

                            claims.Add(new Claim(ClaimTypes.Role, role));

                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );

                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };

                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName Is Invalid");
                }
            }

            return Ok();
        }









        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetWithEmailAndPhone([FromBody] ResetPasswordDto dto)
        {
            var result = await _mediator.Send(new PasswordResetCommand(dto));

            if (result.Succeeded)
                return Ok("Password reset successfully.");

            return BadRequest(result.Errors.Select(e => e.Description));
        }




    }
}
