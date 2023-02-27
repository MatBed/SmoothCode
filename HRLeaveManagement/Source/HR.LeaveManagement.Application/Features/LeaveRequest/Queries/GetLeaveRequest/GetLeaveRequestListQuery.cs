using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;

public record GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
{
}
