using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Trains.API.Context;
using Trains.API.Helper;
using Trains.API.Repositories;

namespace Trains.API
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
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trains.API ", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            builder.Services.AddDbContext<TrainsDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));            

            builder.Services.AddScoped<ITrainsRepository, TrainsRepository>();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}