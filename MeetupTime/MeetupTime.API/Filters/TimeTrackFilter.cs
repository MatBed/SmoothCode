using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MeetupTime.API.Filters;

public class TimeTrackFilter : IActionFilter
{
    private Stopwatch _stopwatch;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();

        var milliseconds = _stopwatch.ElapsedMilliseconds;

        var action = context.ActionDescriptor.DisplayName;

        Debug.WriteLine($"{action} - {milliseconds} ms");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }
}
