using Microsoft.AspNetCore.Authorization;

namespace DotNetIdentityDeepDive.Authorization
{
    public class HRManagerProbationRequirement : IAuthorizationRequirement
    {
        public int ProbabtionMonths { get; }

        public HRManagerProbationRequirement(int probabtionMonths)
        {
            ProbabtionMonths = probabtionMonths;
        }
    }

    public class HRManagerProbabtionRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
        {
            //if(context.User.HasClaim(x => x.Type == "EmploymentDate"))
            //    return Task.CompletedTask;


            //var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate")!.Value);

            var claim = context.User.FindFirst("EmploymentDate");

            if (claim is null)
                return Task.CompletedTask;

            var empDate = DateTime.Parse(claim.Value); // No '!' needed here
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.ProbabtionMonths) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
