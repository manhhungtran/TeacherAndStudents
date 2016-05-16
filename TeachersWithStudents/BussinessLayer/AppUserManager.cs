using DataAccessLayer.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace BussinessLayer
{
    public class AppUserManager : UserManager<AppUser, int>
    {
        public AppUserManager(IUserStore<AppUser, int> store) : base(store)
        {
        }
    }
}
