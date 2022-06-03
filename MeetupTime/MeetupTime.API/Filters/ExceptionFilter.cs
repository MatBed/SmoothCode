using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeetupTime.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        this._logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogCritical($"Critical error: {context.Exception.Message}", context.Exception);

        var result = new JsonResult("Something went wrong!");
        result.StatusCode = 500;

        context.Result = result;
    }
}
