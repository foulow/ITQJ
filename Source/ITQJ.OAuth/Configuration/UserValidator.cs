using IdentityModel;
using ITQJ.Domain.Models;
using ITQJ.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ITQJ.OAuth.Configuration
{
    public class UserValidator : IUserValidator
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public UserValidator(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }

        public async Task<User> AutoProvisionUserAsync(string provider, string userId, IEnumerable<Claim> claims)
        {
            var claimsValues = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsValues.Add(claim.Type, claim.Value);
            };
            var username = (claimsValues.ContainsKey("surname")) ? claimsValues["sub"] : userId;
            var email = (claimsValues.ContainsKey("emailadress")) ? claimsValues["email"] : "annonymous@unknown.com";
            var rolName = (claimsValues.ContainsKey("role")) ? claimsValues["role"] : "rol_profesional";
            var rolId = (rolName == "rol_profesional") ? 1 : 2;

            var user = new User
            {
                UserName = username,
                Password = userId.ToSha256() + username.ToSha256() + email.ToSha256(),
                Email = email,
                RoleId = rolId
            };

            var newUser = await this._applicationDBContext.Users.AddAsync(user);
            await this._applicationDBContext.SaveChangesAsync();

            // TODO: Save additional user info here.

            return newUser.Entity;
        }

        public Task<User> FindByExternalProviderAsync(string provider, string userId)
        {
            return FindByUsernameAsync(userId);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
                user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.Email == username);

            return user;
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
                user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.Email == username);

            return user != null;
        }
    }

    public interface IUserValidator
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<User> FindByUsernameAsync(string username);
        Task<User> FindByExternalProviderAsync(string provider, string userId);
        Task<User> AutoProvisionUserAsync(string provider, string userId, IEnumerable<Claim> claims);
    }
}
