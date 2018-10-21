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
            var connection = @"Server=tcp:smartmillmsater.database.windows.net,1433;Initial Catalog=LatelierFacemashFront20181021070139_db;Persist Security Info=False;User ID=abdelilah;Password=sm@rtmill2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<FaceMashDbContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IFacemashDalService, FacemashDalService>();

            return services;
        }
    }
}