
using Microsoft.OpenApi.Models;
using SimaApp.API.Hubs;
using SimaApp.Application;
using SimaApp.Application.DTOS.Sima;
using SimaApp.Application.Exceptions;
using SimaApp.Infrastructure;
using SimaApp.Persistance;
namespace SimaApp.API
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

            var env = builder.Environment;

            builder.Services.Configure<SimaOptions>(
            builder.Configuration.GetSection("Sima"));

            builder.Configuration
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false);

            builder.Services.AddPersistance(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddPresentation();
            builder.Services.AddApplication();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Sima Kabinet", Version = "v1", Description = "Sima Kabinet swagger." });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "enter token...",
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                    }
                });
            });

            

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactApp", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandlingMiddleware();

            app.UseHttpsRedirection();
            app.UseCors("ReactApp");

            app.UseAuthorization();

            app.MapHub<SimaHub>("/hubs/sima-hub");

            app.MapControllers();

            app.Run();
        }
    }
}
