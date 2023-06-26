using Back_end.Model;
using Back_end;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Back_end.Controllers;


[ApiController]
[Route("new-user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [EnableCors("MainPolicy")]
    public void add ([FromServices]IUserService service, [FromBody]UserTable user)
    {
        service.Add(user);
    }
}
