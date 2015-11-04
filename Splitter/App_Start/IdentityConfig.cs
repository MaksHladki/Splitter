using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Splitter.Common;
using Splitter.Models;

namespace Splitter.App_Start
{
    public class CustomUserManager : UserManager<CustomIdentityUser, int>
    {
        public CustomUserManager(IUserStore<CustomIdentityUser, int> store)
            : base(store)
        {
        }

        public static CustomUserManager Create()
        {
            var manager = new CustomUserManager(new CustomUserStore());
            return manager;
        }
    }

    public class CustomSignInManager : SignInManager<CustomIdentityUser, int>
    {
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(CustomIdentityUser user)
        {
            return user.GenerateUserIdentityAsync(UserManager);
        }
    }
}