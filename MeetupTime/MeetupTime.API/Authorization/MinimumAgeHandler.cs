using Microsoft.AspNetCore.Authorization;

namespace MeetupTime.API.Authorization;

public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);

        if (dateOfBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
