using Microsoft.AspNetCore.Authorization;

namespace ITQJ.API.Authorization
{
    public class SubjectMustMatchUserRequirement : IAuthorizationRequirement
    {
        public SubjectMustMatchUserRequirement()
        {
        }
    }
}
