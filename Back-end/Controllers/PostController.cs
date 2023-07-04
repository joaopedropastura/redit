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
        [FromServices] IPostService postService,
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

        await postService.Add(newPost);
        return Ok();
    }


    public async Task<ActionResult> getCommunities(
        [FromServices] UserService userService,
        [FromBody] UserToken userId,
        [FromServices] IJwtService jwt,
        [FromServices] ICommunityService communityService
    )
    {

        var tokenJwt = jwt.Validate<UserToken>(userId.userId).userId;
        var userAuth = await userService.Filter(x => x.Cpf == tokenJwt);
        return Ok();
    }

    
}