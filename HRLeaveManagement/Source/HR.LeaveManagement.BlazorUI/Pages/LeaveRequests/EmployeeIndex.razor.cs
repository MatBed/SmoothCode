using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class EmployeeIndex
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Inject]
        ILeaveRequestService LeaveRequestService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public EmployeeLeaveRequestViewVM Model { get; set; } = new();

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Model = await LeaveRequestService.GetUserLeaveRequests();
        }

        async Task CancelRequestAsync(int id)
        {
            var confirm = await JSRuntime.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");
            
            if (confirm)
            {
                var response = await LeaveRequestService.CancelLeaveRequest(id);

                if (response.Success)
                {
                    StateHasChanged();
                }
                else
                {
                    Message = response.Message;
                }
            }
        }
    }
}