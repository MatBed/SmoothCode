using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailsDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IUserService userService)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
        var result = _mapper.Map<LeaveRequestDetailsDto>(leaveRequest);

        if (result == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        result.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);

        return result;
    }
}
