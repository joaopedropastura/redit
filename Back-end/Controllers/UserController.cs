using Back_end.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace Back_end.Controllers;


[ApiController]
[Route("new-user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [EnableCors("MainPolicy")]
    public void Add ([FromServices]IUserService service,
        [FromBody]Usertable user, 
        [FromServices]ISecurityService security)
    {
        Usertable newUser = new Usertable();
        newUser.Salt = security.GenerateSalt();
        newUser.Password = security.ApplyHash(user.Password, newUser.Salt);
        user.Password = newUser.Password;
        user.Salt = newUser.Salt;

        service.Add(user);

    }
}
