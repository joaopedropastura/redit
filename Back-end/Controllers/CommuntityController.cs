using Back_end.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Security.Jwt;

[ApiController]
[EnableCors("MainPolicy")]
[Route("forum")]
public class CommunityController : ControllerBase
{
    // [HttpPost("new-forum")]
    // public async Task<ActionResult> Add(
    //     [FromServices] ICommunityService service,
    //     [FromBody] NewComunity community,
    //     [FromServices]IJwtService jwt
    // )
    // {
    //     Comunity newComunity = new Comunity()
    //     {
    //         Id : jwt.Validate<UserToken>(community.jwt).id;
    //     };
    // }
}