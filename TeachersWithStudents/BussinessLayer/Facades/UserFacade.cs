using System.Security.Claims;
using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace BussinessLayer.Facades
{
    public class UserFacade
    {
        public void Register(UserDTO user)
        {
            var userManager = new AppUserManager(new AppUserStore(new AppDbContext()));

            AppUser appUser = Mapping.Mapper.Map<AppUser>(user);

            userManager.Create(appUser, user.Password);

            var ourUser = userManager.FindByName(appUser.UserName);


            var roleManager = new AppRoleManager(new AppRoleStore(new AppDbContext()));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new AppRole { Name = "Admin" });
            }

            userManager.AddToRole(ourUser.Id, "Admin");
        }

        public ClaimsIdentity Login(string email, string password)
        {
            var userManager = new AppUserManager(new AppUserStore(new AppDbContext()));

            var wantedUser = userManager.FindByEmail(email);

            if (wantedUser == null)
            {
                return null;
            }

            AppUser user = userManager.Find(wantedUser.UserName, password);

            return user == null ? null : userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
