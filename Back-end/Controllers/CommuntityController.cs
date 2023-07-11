using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace Back_end.Controllers;
using Back_end.Model;
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
        var state = jwt.Validate<UserToken>(community.jwt).userId;
        
        Comunity newComunity = new Comunity()
        {
            Creator = jwt.Validate<UserToken>(community.jwt).userId,
            Title = community.Title,
            Description = community.Description
        };

        var CommunityExist = await service.Exist( u => u.Title == community.Title);

        if (CommunityExist)
            return Ok(new {Message = "Comunidade ja existente"});
                    

        
        await service.Add(newComunity);
        return Ok( new {Message = "Comunidade criada com sucesso!"});
    }

    [HttpPost("verify-user")]
    public async Task<ActionResult> CommunityLoad(
        [FromBody] IsMember pageData,
        [FromServices] IJwtService jwtService,
        [FromServices] IUserService userService,
        [FromServices] ICommunityService communitySerice,
        [FromServices] IPostService postService
    )
    {
        var validation = jwtService.Validate<IsMember>(pageData.userId);
        if (validation is null)
            return Forbid();

        var cpf = validation.userId;
        var communities = await communitySerice.Filter(x => x.Title == pageData.CommunityName);
        var comunity = communities.FirstOrDefault();

        if (comunity is null)
            return NotFound("Comunidade inexistente");
        
        var posts = await postService.Filter(x => x.IdComunity == comunity.Id);
        
        var postItemList = posts.Select(p => new PostItem {
            UserName = p.IdUserNavigation.Username,
            CommunityName = p.IdComunityNavigation.Title,
            Title = p.Title,
            PostData = p.PostData
        }).ToList();

        var middleTable = await communitySerice.FilterIsMember(
            x => x.IdComunity == comunity.Id && 
            x.IdUser == cpf
        );

        CommunityData data = new CommunityData()
        {
            InCommunity = middleTable.Count() > 0 ? true : false,
            Description = comunity.Description,
            CommunityName = comunity.Title,
            Members = middleTable.Count(),
            PostList = postItemList,
            UserNameOwner = comunity.CreatorNavigation.Username
        };
        
        return Ok(data);
    }

     [HttpPost("add-user")]
    public async Task<ActionResult> AddMember(
        [FromBody] IsMember pageData,
        [FromServices] IJwtService jwtService,
        [FromServices] IUserService userService,
        [FromServices] ICommunityService communitySerice
    )
    {
        var tokenJwt = jwtService.Validate<IsMember>(pageData.userId).userId;
        var userAuth = await userService.Filter(x => x.Cpf == tokenJwt);
        var user = userAuth.FirstOrDefault();
        var communityName = await communitySerice.Filter(x => x.Title == pageData.CommunityName);
        var communityObj = communityName.FirstOrDefault();        

        var newMember = new HasResponsibility()
        {
            IdComunity = communityObj.Id,
            IdUser = user.Cpf,
            IdResponsibility = 1
        };

        await communitySerice.AddMember(newMember);
        
        return Ok( new {Message = "novo membro adicionado com sucesso"}); 
    }

    [HttpPost("get-communities")]
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