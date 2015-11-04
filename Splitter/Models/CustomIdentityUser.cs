using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.Model.DTO;
using Splitter.Common;

namespace Splitter.Models
{
    public class CustomIdentityUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public User User { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomIdentityUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("Id", Id.ToString()));
            return userIdentity;
        }

        public CustomIdentityUser(int userId)
        {
            Id = userId;
        }

        public CustomIdentityUser(User user)
            : this(user.Id)
        {
            User = user;
            UserName = user.Login;
            Email = user.Email;
            PasswordHash = user.Password;
        }
    }
}