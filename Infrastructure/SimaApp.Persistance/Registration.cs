using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Infrastructure.Sima;
using SimaApp.Persistance.Context;
using SimaApp.Persistance.Repositories;
using SimaApp.Persistance.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt=>
            opt.UseSqlServer(configuration.GetConnectionString("MSSQL")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISimaContractService, SimaContractService>();
            services.AddScoped<IGeneratorService, GeneratorManager>();

        }
    }
}
