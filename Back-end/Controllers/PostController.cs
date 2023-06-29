using Back_end.Model;
using Security.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

[ApiController]
[EnableCors("MainPolicy")]
[Route("post")]
public class PostController : ControllerBase
{
    [HttpPost("new-post")]
    public async Task<ActionResult> Add(

    )
    {
        
    }
}