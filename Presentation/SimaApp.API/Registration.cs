using Microsoft.EntityFrameworkCore;
using SimaApp.API.Services;
using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Infrastructure.Sima;
using SimaApp.Persistance.Context;
using SimaApp.Persistance.Repositories;
using SimaApp.Persistance.UnitOfWorks;

namespace SimaApp.API
{
    public static class Registration
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddSignalR();

            services.AddScoped<ISimaNotifier, SimaNotifier>();
        }
    }
}
