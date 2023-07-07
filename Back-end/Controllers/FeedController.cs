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
        var listCommunity = await communityService.Filter(x => x.Id > 0);
        // var user = await userService.Filter(x => x.Cpf == userAuth);
        // System.Console.WriteLine(user);

        return Ok(listCommunity);
    }

    [HttpPost ("list-posts-feed")]
    public async Task<ActionResult> getPostFeed(
        [FromBody] UserToken UserId,
        [FromServices] IJwtService jwt,
        [FromServices] IUserService userService,
        [FromServices] IPostService postService,
        [FromServices] ICommunityService communityService

    )
    {
        var tokenJwt = jwt.Validate<UserToken>(UserId.userId).userId;
        var userAuth = await userService.Filter(x => x.Cpf == tokenJwt);
        var user = userAuth.FirstOrDefault();

        var postsLinked = await postService.Filter(x => x.IdUser == user.Cpf);
        var listPosts = postsLinked.Select(post => new NewPost()
            {
                UserId = post.IdUser, 
                Title = post.Title,
                PostData = post.PostData,
                CommunityId = post.IdComunity
            });
        return Ok(listPosts);
    }


}