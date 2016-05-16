using DataAccessLayer.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace BussinessLayer
{
    public class AppRoleManager : RoleManager<AppRole, int>
    {
        public AppRoleManager(IRoleStore<AppRole, int> store) : base(store)
        {
        }
    }
}
