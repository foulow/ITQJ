using ITQJ.EFCore.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.API.Authorization
{
    public class SubjectMustBePublisherHandler : AuthorizationHandler<SubjectMustBePublisherRequirement>
    {
        private readonly HttpContextAccessor _httpContexAccessor;
        private readonly ApplicationDBContext _applicationDBContext;
        public SubjectMustBePublisherHandler(HttpContextAccessor httpContexAccessor, ApplicationDBContext applicationDBContext)
        {
            _httpContexAccessor = httpContexAccessor ??
                throw new ArgumentNullException(nameof(httpContexAccessor));

            _applicationDBContext = applicationDBContext ??
                throw new ArgumentNullException(nameof(applicationDBContext));
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubjectMustBePublisherRequirement requirement)
        {
            var projectId = _httpContexAccessor.HttpContext.GetRouteValue("projectId").ToString();
            if (!Guid.TryParse(projectId, out Guid projectIdAsGuid))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var ownerId = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (_applicationDBContext.Projects.Any(m => m.Id == projectIdAsGuid && m.UserId == Guid.Parse(ownerId)))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
