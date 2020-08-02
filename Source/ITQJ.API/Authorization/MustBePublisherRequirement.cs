using Microsoft.AspNetCore.Authorization;

namespace ITQJ.API.Authorization
{
    public class MustBePublisherRequirement : IAuthorizationRequirement
    {
        public MustBePublisherRequirement()
        {

        }
    }
}
