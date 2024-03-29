using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Edit
{
    [Inject]
    ILeaveTypeService _client { get; set; }

    [Inject]
    NavigationManager _navManager { get; set; }

    [Parameter]
    public int Id { get; set; }

    public string Message { get; private set; }

    LeaveTypeVM leaveType = new LeaveTypeVM();

    protected async override Task OnParametersSetAsync()
    {
        leaveType = await _client.GetLeaveTypeDetails(Id);
    }

    async Task EditLeaveType()
    {
        var response = await _client.UpdateLeaveType(Id, leaveType);

        if (response.Success)
        {
            _navManager.NavigateTo("/leavetypes/");
        }

        Message = response.Message;
    }
}