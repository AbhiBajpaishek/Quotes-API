using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quotes_API.Entity;

namespace Quotes_API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController :ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager; 
            _userManager = userManager;   
        }

        [HttpGet]
        public async Task<IList<IdentityRole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        } 

        [HttpGet("GetRoleById")]
        public async Task<RoleResponse> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var users = await _userManager.Users.ToListAsync();
            var roleResponse = new RoleResponse(){
                RoleId = role.Id,
                RoleName =role.Name,
                Users = new List<IdentityUser>()
            };
            foreach(var user in users)
            {
                var hasRole = await _userManager.IsInRoleAsync(user,role.Name);
                if(hasRole)
                    roleResponse.Users.Add(user);
            }
            return roleResponse;
        } 

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole(UserRoles userRole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole(){
                    Name = userRole.RoleName
                };

                var result = await _roleManager.CreateAsync(identityRole);
                var roleCreated = await _roleManager.FindByNameAsync(userRole.RoleName);
                if(result.Succeeded)
                {
                    return Ok(new RoleResponse(){
                        RoleName= userRole.RoleName,
                        RoleId = roleCreated.Id,
                        ResponseMessage = "Role Created Succesfully!!",
                        ResponseCode =  StatusCodes.Status201Created
                    });
                }
                else{
                    IList<string> errors = new List<string>();
                    foreach(IdentityError err in result.Errors)
                    {
                        errors.Add(err.Description);
                    }

                    return Ok(new RoleResponse(){
                        RoleName=userRole.RoleName,
                        ResponseMessage = "Role not created, check ResponseErrors for reasons",
                        ResponseCode = StatusCodes.Status202Accepted,
                        ResponseError = errors
                    });
                }
            }
            return Ok();
        }
    }
}