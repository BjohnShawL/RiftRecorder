using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace R_R.Common.Entities
{
    public class R_RUser : IdentityUser
    {
        public string Token { get; set; }
        public DateTime TokenExpires { get; set; }
        [NotMapped]
        public List<Claim> Claims { get; set; } = new List<Claim>();

    }
}
