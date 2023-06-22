using Microsoft.AspNetCore.Mvc;
namespace Back_end.Controllers;
using Back_end.Model;

[ApiController]
[Route("new-user")]
public class CreateUser : ControllerBase
{
    [HttpPost]
    public void Add([FromBody] UserTable usertb)
    {
        
    }
}
