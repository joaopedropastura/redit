public class WebApplication
{
    public static WebApplication CreateBuilder(string[] args)
    {
        return new WebApplication();
    }

    public WebApplication Services => this;

    public void AddControllers() { }
    public void AddEndpointsApiExplorer() { }
    public void AddSwaggerGen() { }

    public void AddCors(Action<WebApplication> opts) { }
    public void AddPolicy(string name, Action<WebApplication> policy) { }

    public WebApplication AllowAnyHeader() => this;
    public WebApplication AllowAnyOrigin() => this;
    public WebApplication AllowAnyMethod() => this;

    public void AddScoped<T>(){}
    public void AddTransient<T, R>(){}
    public void AddTransient<T>(Func<WebApplication, object> a){}

    public WebApplication Build() => this;

    public WebApplication Environment => this;

    public bool IsDevelopment() => true;

    public void UseSwagger() { }
    public void UseSwaggerUI() { }
    public void UseHttpsRedirection() { }
    public void UseAuthorization() { }
    public void MapControllers() { }
    public void UseCors() { }
    public void Run()
    {
        while (true)
        {
            Console.ForegroundColor = new ConsoleColor[]
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.Gray,
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.White
            }[Random.Shared.Next(7)];
            Thread.Sleep(200);
            Console.WriteLine("Você foi goiabado kk");
        }
     }
}