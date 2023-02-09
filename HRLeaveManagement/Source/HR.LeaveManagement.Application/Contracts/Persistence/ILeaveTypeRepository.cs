using HR.LeaveManagement.Core;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IfLeaveTypeUnique(string name);
}
