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
        [FromServices] IJwtService jwt,
        [FromBody] NewPost post
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

    

    [HttpPost ("list-posts")]
    public async Task<ActionResult> getPosts(
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
        var postsLink = postsLinked.FirstOrDefault();
        if (postsLink is null)
            return Ok( new { Message = "nenhum post"} );
        var community =  await communityService.Filter(x => x.Id == postsLink.IdComunity);
        var communityName = community.FirstOrDefault();

        var sla = postsLinked.Select(post => new PostItem()
            {
                Title = post.Title,
                PostData = post.PostData,
                CommunityName = communityName.Title,
                UserName = user.Username
            });


        return Ok(sla);
    }
        [HttpPost ("feed-list-posts")]
    public async Task<ActionResult> getPostsFeed(
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
        var postsLink = postsLinked.FirstOrDefault();
        if (postsLink is null)
            return Ok( new { Message = "nenhum post"} );
        var community =  await communityService.Filter(x => x.Id == postsLink.IdComunity);
        var communityName = community.FirstOrDefault();

        var sla = postsLinked.Select(post => new PostItem()
            {
                Title = post.Title,
                PostData = post.PostData,
                CommunityName = communityName.Title,
                UserName = user.Username
            });


        return Ok(sla);
    }
}