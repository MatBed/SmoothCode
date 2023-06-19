using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Conntracts;

public interface ILeaveAllocationService
{
    Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
}
