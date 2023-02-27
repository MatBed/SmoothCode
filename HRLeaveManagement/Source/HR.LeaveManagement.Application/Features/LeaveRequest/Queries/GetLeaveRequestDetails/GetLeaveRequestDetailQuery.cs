using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public record GetLeaveRequestDetailQuery(int Id) : IRequest<LeaveRequestDetailsDto>;
