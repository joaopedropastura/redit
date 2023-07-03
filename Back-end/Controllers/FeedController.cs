using Back_end.Model;
using Security.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

[ApiController]
[EnableCors("MainPolicy")]
[Route("post")]
public class FeedController : ControllerBase
{
    [HttpPost ("list-communities")]
    public async Task<ActionResult> getCommunity(
        [FromServices] ICommunityService communityService,
        [FromServices] IJwtService jwt,
        [FromServices] IUserService userService,
        [FromBody] UserToken UserId
    )
    {
        var userAuth = jwt.Validate<UserToken>(UserId.userId).userId;
        var listCommunity =  await communityService.Filter(x => x.Id > 0);
        
        var temp = await userService.Filter(x => x.Cpf == userAuth);

        
        System.Console.WriteLine(temp);

        
        return Ok(listCommunity);
    }

    [HttpGet ("list-posts")]
    public async Task<ActionResult> getPosts(
        [FromBody] UserToken UserId,
        [FromServices] IJwtService jwt,
        [FromServices] IUserService userService,
        [FromServices] IPostService postService
    )
    {
        var tokenJwt = jwt.Validate<UserToken>(UserId.userId).userId;
        var userAuth = userService.Filter(x => x.Cpf == tokenJwt);

        return Ok();
    }
}