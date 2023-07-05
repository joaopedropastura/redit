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
    public async Task<ActionResult> IsMember(
        [FromBody] IsMember pageData,
        [FromServices] IJwtService jwtService,
        [FromServices] IUserService userService,
        [FromServices] ICommunityService communitySerice
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

        var middleTable = await communitySerice.FilterIsMember(
            x => x.IdComunity == comunity.Id && 
            x.IdUser == cpf
        );
        
        return Ok(new
        {
            InCommunity = middleTable.Count() > 0
        });
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

        var middleTable = await communitySerice.FilterIsMember(x => x.IdComunity == communityName[0].Id);
        
        System.Console.WriteLine(middleTable[0]);
        return Ok(); 
    }
}