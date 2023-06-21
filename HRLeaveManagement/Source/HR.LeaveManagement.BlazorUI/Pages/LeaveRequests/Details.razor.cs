using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Details
    {
        [Inject]
        ILeaveRequestService leaveRequestService { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [Parameter]
        public int id { get; set; }

        public LeaveRequestVM Model { get; private set; } = new LeaveRequestVM();

        string ClassName;
        string HeadingText;

        protected override async Task OnParametersSetAsync()
        {
            Model = await leaveRequestService.GetLeaveRequest(id);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Model.Approved == null)
            {
                ClassName = "warning";
                HeadingText = "Pending Approval";
            }
            else if (Model.Approved == true)
            {
                ClassName = "success";
                HeadingText = "Approved";
            }
            else
            {
                ClassName = "danger";
                HeadingText = "Rejected";
            }
        }

        async Task ChangeApproval(bool approvalStatus)
        {
            await leaveRequestService.ApproveLeaveRequest(id, approvalStatus);
            navigationManager.NavigateTo("/leaverequests/");
        }
    }
}