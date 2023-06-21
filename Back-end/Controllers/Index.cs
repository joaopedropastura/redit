using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[ApiController]
[Route("")]
public class Index : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "oi";
    }
}