using Back_end.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Security.Jwt;

[ApiController]
[EnableCors("MainPolicy")]
[Route("forum")]
public class CommunityController : ControllerBase
{
    [HttpPost("new-forum")]
    public async Task<ActionResult> Add(
        [FromServices] ICommunityService service,
        [FromBody] NewComunity community,
        [FromServices]IJwtService jwt
    )
    {
        var state = jwt.Validate<UserToken>(community.jwt).id;
        
        Comunity newComunity = new Comunity()
        {
            Creator = jwt.Validate<UserToken>(community.jwt).id,
            Title = community.Title,
            Description = community.Description
        };

        await service.Add(newComunity);
        return Ok( new {Message = "Comunidade criada com sucesso!"});
    }
}