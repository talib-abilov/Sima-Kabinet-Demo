using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimaApp.Application.Interfaces.Redis;
using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Application.Interfaces.Tokens;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Infrastructure.Redis;
using SimaApp.Infrastructure.Services;
using SimaApp.Infrastructure.Sima;
using SimaApp.Infrastructure.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IConnectionMultiplexer>(_ =>
           ConnectionMultiplexer.Connect(
               configuration["Redis:ConnectionString"]!));

            services.AddScoped<IRedisService, RedisService>();
            //services.AddScoped<IFileStorageService,FileStorageService>();

            //services.AddScoped<IFileService, CloudinaryFileStorageService>();

            services.AddScoped<IFileService, FileService>();
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService, TokenService>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>{
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });

        }
    }
}
