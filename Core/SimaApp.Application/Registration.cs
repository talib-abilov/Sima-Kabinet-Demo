using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimaApp.Application.Bases;
using SimaApp.Application.Behaviors;
using SimaApp.Application.Exceptions;
using SimaApp.Application.Features.Companies.Rules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services )
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
           

            services.AddValidatorsFromAssembly( assembly );
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));

            services.AddMediatR(cnf=>cnf.RegisterServicesFromAssembly(assembly));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type!= t).ToList();

            foreach(var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }
    }

}
