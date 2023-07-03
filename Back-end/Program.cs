using Back_end.Model;
using Back_end.Services;

using Security.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

builder.Services.AddScoped<RedeSocialContext>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddTransient<ICommunityService, CommunityService>();

builder.Services.AddTransient<IPasswordProvider>( p => {
    return new PasswordProvider("carioca");
});

builder.Services.AddTransient<IJwtService, JwtService>();



// builder.Services.AddTransient<INewUser<UserTable>, NewUser>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();