using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Quotes_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SecurityController : ControllerBase
    { 
        [HttpGet]
        public void GetToken(string username)
        {
            //assuming that this user credentials are good
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mykey@123"));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var claims = new []{
                new Claim("Issuer","Abhi")
            };

        }

       
    }
}