using Microsoft.AspNetCore.Mvc;

namespace MeetupTime.API.Controllers;

[Route("config")]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpOptions("reload")]
    public ActionResult Reload()
    {
        try
        {
            ((IConfigurationRoot)_configuration).Reload();

            return Ok();
        }
        catch(Exception ex)
        {
            return StatusCode(500);
        }
    }
}
