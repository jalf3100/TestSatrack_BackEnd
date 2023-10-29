//-----------------------------------------------------------------------
// <copyright file = "InjectionExtensions.cs" company="Satrack">
//     Copyright(c) Satrack.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Satrack.Extensions
{
    using Infrestructure.Satrack.Persistences.Contexts;
    using Infrestructure.Satrack.Persistences.Interfaces;
    using Infrestructure.Satrack.Persistences.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Clase para la Inyección de Dependencias entre las interfaces y las clases UnitOfWork, GenericRepository</summary>
    public static class InjectionExtensions
    {
        #region [Methods]
        /// <summary>Método para inyectar las dependencias entre las interfaces y las clases UnitOfWork, GenericRepository</summary>
        /// <param name="services">Servicio para poder agregar las dependencias</param>
        /// <param name="configuration">Configuración necesaria para poder implementar el DbContext</param>
        /// <returns></returns>
        public static IServiceCollection AddInjectionInfrestructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? assembly = typeof(SatrackContext).Assembly.FullName;
            services.AddDbContext<SatrackContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SatrackConnection"), b => b.MigrationsAssembly(assembly)),
                ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
        #endregion [Methods]
    }
}