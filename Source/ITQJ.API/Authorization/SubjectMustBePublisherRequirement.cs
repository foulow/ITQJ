using Microsoft.AspNetCore.Authorization;

namespace ITQJ.API.Authorization
{
    public class SubjectMustBePublisherRequirement : IAuthorizationRequirement
    {
        public SubjectMustBePublisherRequirement()
        {

        }
    }
}
