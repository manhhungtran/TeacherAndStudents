using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // neco 
        }

    }
}
