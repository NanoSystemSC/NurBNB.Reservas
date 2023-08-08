using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NurBNB.Reservas.Domain.Factories;
using NurBNB.Reservas.Domain.Model.Clientes;

namespace NurBNB.Reservas.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IHuespedFactory, HuespedFactory>();
            services.AddSingleton<IPropiedadFactory, PropiedadFactory>();
            services.AddSingleton<IReservaFactory, ReservaFactory>();
            services.AddSingleton<ICancelarFactory, CancelarFactory>();

            //services.AddSingleton<Itipocan>

            return services;
        }
    }
}
