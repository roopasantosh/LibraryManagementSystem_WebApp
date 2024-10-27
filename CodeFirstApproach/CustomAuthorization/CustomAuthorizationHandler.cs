namespace LibraryManagementProject.CustomAuthorization
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    public class CustomAuthorizationHandler : AuthorizationHandler<CustomRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == requirement.RequiredClaim))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }

}
