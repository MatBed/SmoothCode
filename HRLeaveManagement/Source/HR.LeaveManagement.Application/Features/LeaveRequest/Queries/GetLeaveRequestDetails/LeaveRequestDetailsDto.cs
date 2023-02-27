using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class LeaveRequestDetailsDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ReqestingEmplyeeId { get; set; }

    public LeaveTypeDto LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }

    public string RequestedComments { get; set; }

    public DateTime? DateActionde { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }
}
