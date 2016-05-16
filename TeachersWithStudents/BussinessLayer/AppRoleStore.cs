using System.Data.Entity;
using DataAccessLayer.IdentityEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BussinessLayer
{
    public class AppRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public AppRoleStore(DbContext context) : base(context)
        {
        }
    }
}
