using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quotes_API.Entity;

namespace Quotes_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        public UserManager<IdentityUser> _userManager { get; }
        public SignInManager<IdentityUser> _signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegistration registrationModel)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser(){UserName= registrationModel.Email,Email=registrationModel.Email};
                var result = await _userManager.CreateAsync(user,registrationModel.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    return Ok();
                }
            }
            
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email,login.Password,login.RememberMe,false);
                if(result.Succeeded)
                    return Ok("Signed in Succesfully");
                
                ModelState.AddModelError(string.Empty,"Wrong Crdentials!!");
            }
            return Unauthorized();

        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string email)
        {
            await _signInManager.SignOutAsync();
            return Ok("LoggedOut!!");
        }
    }
}