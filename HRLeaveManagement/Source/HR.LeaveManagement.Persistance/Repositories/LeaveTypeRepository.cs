using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Core;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;
public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IfLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name) == false;
    }
}