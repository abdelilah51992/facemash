using Latelier.Facemash.Dal.Interface;
using Latelier.Facemash.Dal.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Latelier.Facemash.Dal
{
    /// <summary>
    /// Dependency injection - collecte services
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Add face mash Dal service dendency services
        /// </summary>
        /// <param name="services">services</param>
        /// <returns>services</returns>
        public static IServiceCollection AddFaceMashDalService(this IServiceCollection services)
        {
            var connection = @"Server = (localdb)\v11.0; Database = FaceMash; Trusted_Connection = True;";
            services.AddDbContext<FaceMashDbContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IFacemashDalService, FacemashDalService>();

            return services;
        }
    }
}