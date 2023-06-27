using Back_end.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;



[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [EnableCors("MainPolicy")]
    public void Verify ()
    {
        
    }
}