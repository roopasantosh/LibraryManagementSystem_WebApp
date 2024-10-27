namespace LibraryManagementProject.CustomAuthorization
{
    using Microsoft.AspNetCore.Authorization;

    public class CustomRequirement : IAuthorizationRequirement
    {
        public string RequiredClaim { get; }

        public CustomRequirement(string requiredClaim)
        {
            RequiredClaim = requiredClaim;
        }
    }

}
