using Emeraldcave.Api.ApiResponses;
using Emeraldcave.Api.Models.AuthModels;
using Emeraldcave.Domain.Entities;
using Emeraldcave.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Emeraldcave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly ITokenService _tokenService;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var email = await _userManager.FindByEmailAsync(model.Email);
            if (email != null)
                return StatusCode(StatusCodes.Status400BadRequest, new AuthResponseDto { Status = "Error", Message = "User already exists" });
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                AltPhoneNumber = model.AltPhoneNumber,
                Email = model.Email,
                UserName = model.Username,
                Addresses = model.Addresses.Select(i => 
                new Address
                {
                    City = i.City,
                    State = i.State,
                    StreetAddress = i.StreetAddress,
                    ZipCode = i.ZipCode
                }).ToList()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var confirmationToken = Url.Action("ConfirmEmail", "Account", new { user.Email, code }, protocol: HttpContext.Request.Scheme);
                return StatusCode(StatusCodes.Status200OK, new AuthResponseDto { Status = "Success", Message = "User created successfully", Data = model });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new AuthResponseDto { Status = "Error", Message = "User creation failed" });

        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return StatusCode(StatusCodes.Status401Unauthorized, new AuthResponseDto { Status = "Bad Request", Message = "Invalid credentials" });
            var result = await _signinManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            { 
                return StatusCode(StatusCodes.Status200OK, new LoginResponseDto { DisplayName = user.FirstName, Email = user.Email, Token = _tokenService.CreateToken(user) });
            }
            return StatusCode(StatusCodes.Status401Unauthorized, new AuthResponseDto { Status = "Bad Request", Message = "Invalid credentials" });
        }
    } 
}
