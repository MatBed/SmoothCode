using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Index
    {
        [Inject]
        ILeaveRequestService LeaveRequestService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public AdminLeaveRequestViewVM Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model = await LeaveRequestService.GetAdminLeaveRequestList();
        }

        void GoToDetails(int id)
        {
            NavigationManager.NavigateTo($"/leaverequests/details/{id}");
        }
    }
}