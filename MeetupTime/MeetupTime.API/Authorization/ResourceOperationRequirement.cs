using Microsoft.AspNetCore.Authorization;

namespace MeetupTime.API.Authorization;

public enum OperationType
{
    Create,
    Update,
    Delete,
    Read
}

public class ResourceOperationRequirement : IAuthorizationRequirement
{
    public OperationType OperationType { get; set; }

    public ResourceOperationRequirement(OperationType operationType)
    {
        OperationType = operationType;
    }
}
