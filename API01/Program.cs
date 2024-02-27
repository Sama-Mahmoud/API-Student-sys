
using API01.Models;
using API01.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IStudentReb, StudentRebo>();
            builder.Services.AddSingleton<IDepartment, DepartmentRebo>();
            builder.Services.AddDbContext<CompanyContext>(opt=>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con"));


                },  ServiceLifetime.Singleton
);
            builder.Services.AddCors(Options =>
            {
                Options.AddPolicy("MyPolicy" , corspolicy =>
                {
                    corspolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }
                    
                    );
            }
                
                );
            var app = builder.Build();
            app.Use(async (context, next) =>
            {
                Console.WriteLine("before middeleware 1");
                await next();
                Console.WriteLine("before middeleware 1");
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
