using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Conntracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Blazored.Toast.Services;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ILeaveTypeService LeaveTypeService { get; set; }

    [Inject]
    public ILeaveAllocationService LeaveAllocationService { get; set; }

    [Inject]
    IToastService ToastService { get; set; }

    public List<LeaveTypeVM> LeaveTypes { get; private set; }

    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        LeaveTypes = await LeaveTypeService.GetLeaveTypes();
    }

    protected void CreateLeaveType()
    {
        NavigationManager.NavigateTo("/leavetypes/create/");
    }

    protected void AllocateLeaveType(int id)
    {
        LeaveAllocationService.CreateLeaveAllocations(id);
    }

    protected void EditLeaveType(int id)
    {
        NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
    }

    protected void DetailsLeaveType(int id)
    {
        NavigationManager.NavigateTo($"/leavetypes/details/{id}");
    }

    protected async Task DeleteLeaveType(int id)
    {
        var response = await LeaveTypeService.DeleteLeaveType(id);

        if (response.Success)
        {
            ToastService.ShowSuccess("Leave type deleted successfully.");
            await OnInitializedAsync();
        }
        else
        {
            Message = response.Message;
        }
    }
}