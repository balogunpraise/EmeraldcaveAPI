using Emeraldcave.Api.ApiResponses;
using Emeraldcave.Api.Models.AuthModels;
using Emeraldcave.Domain.Entities;
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


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
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
    }
}
