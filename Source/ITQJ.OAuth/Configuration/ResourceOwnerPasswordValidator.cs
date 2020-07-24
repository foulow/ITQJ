using IdentityModel;
using IdentityServer4.Validation;
using ITQJ.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ITQJ.OAuth.Configuration
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ResourceOwnerPasswordValidator(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.UserName == context.UserName && x.Password == context.Password.ToSha256());

            if (user == null)
                user = await this._applicationDBContext.Users
                .FirstOrDefaultAsync(x => x.Email == context.UserName && x.Password == context.Password.ToSha256());

            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), authenticationMethod: "custom");
            }
            else
            {
                context.Result = new GrantValidationResult(IdentityServer4.Models.TokenRequestErrors.InvalidGrant, "Invalid Credentials");
            }
        }
    }
}