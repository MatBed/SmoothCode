using HR.LeaveManagement.Core.Common;

namespace HR.LeaveManagement.Core;

public class LeaveType : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }
}
