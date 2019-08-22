using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R_R.Common.Entities;

namespace R_R.Database.Contexts
{
    public class R_RContext : IdentityDbContext<R_RUser>
    {
        public R_RContext(DbContextOptions<R_RContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
