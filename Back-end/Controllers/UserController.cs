using Back_end.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace Back_end.Controllers;
using security_jwt;


[ApiController]
[Route("new-user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [EnableCors("MainPolicy")]
    public void Add ([FromServices]IUserService service, [FromBody]Usertable user)
    {
        
        service.Add(user);
    }
}
