using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Quotes_API.Entity
{
    public class RoleResponse
    {
        public RoleResponse()
        {
            
        }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public IList<IdentityUser> Users { get; set; }
        public string ResponseMessage { get; set; }
        public IList<string> ResponseError { get; set; }
        public int ResponseCode { get; set; }
    }
}