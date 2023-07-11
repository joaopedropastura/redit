using Back_end.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Security.Jwt;
namespace Back_end.Controllers;


[ApiController]
[EnableCors("MainPolicy")]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("new-user")]
    public async Task<ActionResult> Add (
        [FromServices]IUserService service,
        [FromBody]RegisterData user, 
        [FromServices]ISecurityService security)
    {
        
        var query = await service.Filter(u => u.Username == user.Username || u.Email == user.Email);

        if(query.Count() > 0)
            return BadRequest("Já existe");
        
        string salt = security.GenerateSalt();
        byte[] password = security.ApplyHash(user.Password, salt);

        Usertable cadastro = new Usertable()
        {
            Username = user.Username,
            Name = user.Name,
            Cpf = user.Cpf,
            Password = password,
            Salt = salt,
            Borndate = user.DataNasc,
            Email = user.Email
        };
        
        await service.Add(cadastro);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<Jwt>> Login(
        [FromServices]IUserService service,
        [FromBody] LoginData user, 
        [FromServices] ISecurityService security,
        [FromServices] IJwtService jwtService)
    {
        var emailExist = await service.Exist(u => u.Email == user.Email);

        if(!emailExist) {
            return Ok(new {Message = "Usuario não cadastrado"});
        }
        
        Usertable actUser = await service.FindByEmail(user.Email);

        var hashedInput = security.ApplyHash(user.Password, actUser.Salt);
        if(security.Validate(actUser.Password, hashedInput))
        {
            var jwt = jwtService.GetToken<UserToken>(new UserToken { userId = actUser.Cpf });
            System.Console.WriteLine(jwt);
            return Ok(new Jwt(){ Value =  jwt});
        } 

        return Ok(new {Message = "Usuario ou senha incorretos"});
    }

    [HttpPost("profile-page")]
    public async Task<ActionResult> ProfilePage(
        [FromBody] UserToken userId,
        [FromServices] IJwtService jwt,
        [FromServices]IUserService userService,
        [FromServices] IPostService postsService
    )
    {
        var tokenJwt = jwt.Validate<UserToken>(userId.userId).userId;
        var userAuth = await userService.Filter(x => x.Cpf == tokenJwt);
        var user = userAuth.FirstOrDefault();

        if(user is null)
            return NotFound("User not found");

        var posts = await postsService.Filter(x => x.IdUser == user.Cpf);

        var postItemList = posts.Select( p => new PostItem {
            UserName = p.IdUserNavigation.Username,
            Title = p.Title,
            PostData = p.PostData,
            CommunityName = p.IdComunityNavigation.Title
        }).ToList();

        ProfileData data = new ProfileData()
        {
            AssignDate = user.Assigndate,
            BornDate = user.Borndate,
            Name = user.Name,
            PostList = postItemList
        };


        foreach(var p in data.PostList)
        {
            System.Console.WriteLine(p.Title);
        }

        return Ok(data);
    }
}