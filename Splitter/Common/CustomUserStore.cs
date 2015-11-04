using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Splitter.Models;

namespace Splitter.Common
{
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomUserStore :
        IUserLoginStore<CustomIdentityUser, int>,
        IUserPasswordStore<CustomIdentityUser, int>,
        IUserEmailStore<CustomIdentityUser, int>,
        IUserRoleStore<CustomIdentityUser, int>,
        IUserLockoutStore<CustomIdentityUser, int>,
        IUserTwoFactorStore<CustomIdentityUser, int>
    {

        public void Dispose()
        {

        }

        public Task CreateAsync(CustomIdentityUser user)
        {
            user.User.Password = user.PasswordHash;
            var o = RepositoryManager.Instance.UserRepository.Add(user.User);
            return Task.FromResult(o);
        }

        public Task<CustomIdentityUser> FindByIdAsync(int userId)
        {
            var user = RepositoryManager.Instance.UserRepository.GetById(userId);
            if (user != null)
            {
                return Task.FromResult(new CustomIdentityUser(user));
            }
            return Task.FromResult<CustomIdentityUser>(null);
        }

        public Task<CustomIdentityUser> FindByNameAsync(string userName)
        {
            var user = RepositoryManager.Instance.UserRepository.GetByLogin(userName);

            if (user != null)
            {
                return Task.FromResult(new CustomIdentityUser(user));
            }
            return Task.FromResult<CustomIdentityUser>(null);
        }

        public Task SetPasswordHashAsync(CustomIdentityUser user, string passwordHash)
        {
            return Task.FromResult(user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(CustomIdentityUser user)
        {
            var dbUser = RepositoryManager.Instance.UserRepository.GetByLogin(user.UserName);
            if (dbUser != null)
                return Task.FromResult(dbUser.Password);
            return Task.FromResult<string>(null);
        }

        public Task AddToRoleAsync(CustomIdentityUser user, string roleName)
        {
            return Task.FromResult(user);
        }

        public Task<IList<string>> GetRolesAsync(CustomIdentityUser user)
        {
            IList<string> list = new string[] { };
            return Task.FromResult(list);
        }

        public Task<bool> GetLockoutEnabledAsync(CustomIdentityUser user)
        {
            return Task.FromResult(true);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomIdentityUser user)
        {
            return Task.FromResult(new DateTimeOffset());
        }

        public Task<int> GetAccessFailedCountAsync(CustomIdentityUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomIdentityUser user)
        {
            return Task.FromResult(true);
        }


        #region Not implemented methods

        public Task UpdateAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(CustomIdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(CustomIdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(CustomIdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(CustomIdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(CustomIdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(CustomIdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(CustomIdentityUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(CustomIdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(CustomIdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}