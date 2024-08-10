using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            string ConnectionServciesVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(optionX => optionX.UseSqlServer(ConnectionServciesVar));


            //builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddScoped<IUserRepository, UserService>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapControllers();

            app.Run();
        }
    }
}
