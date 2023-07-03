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
        [FromServices] IPostService service,
        [FromBody] NewPost post,
        [FromServices] IJwtService jwt
    )
    {
        Post newPost = new Post()
        {
            Title = post.Title,
            PostData = post.PostData,
            IdComunity = post.CommunityId,
            IdUser = jwt.Validate<UserToken>(post.UserId).userId,
            DatePublish = DateTime.Now
        };

        await service.Add(newPost);
        return Ok();
    }

    
}