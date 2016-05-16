using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using DataAccessLayer.IdentityEntities;

namespace BussinessLayer
{
    public class AppUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppUserStore(DbContext context) : base(context)
        {
            
        }
    }
}
