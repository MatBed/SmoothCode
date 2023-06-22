using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Blazored.Toast.Services;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Create
{
    [Inject]
    NavigationManager NavManager { get; set; }

    [Inject]
    ILeaveTypeService Client { get; set; }

    [Inject]
    IToastService ToastService { get; set; }

    public string Message { get; private set; }

    LeaveTypeVM leaveType = new LeaveTypeVM();

    async Task CreateLeaveType()
    {
        var response = await Client.CreateLeaveType(leaveType);

        if (response.Success)
        {
            ToastService.ShowSuccess("Leave type created successfully.");
            NavManager.NavigateTo("/leavetypes/");
        }

        Message = response.Message;
    }
}