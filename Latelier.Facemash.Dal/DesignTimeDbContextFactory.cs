using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Latelier.Facemash.Dal
{
    /// <summary>
    /// Desing Time db context factory
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FaceMashDbContext>
    {
        /// <summary>
        /// Create db context
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns>Context</returns>
        public FaceMashDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FaceMashDbContext>();
            var connectionString = @"Server=tcp:smartmillmsater.database.windows.net,1433;Initial Catalog=LatelierFacemashFront20181021070139_db;Persist Security Info=False;User ID=abdelilah;Password=sm@rtmill2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.UseSqlServer(connectionString);
            return new FaceMashDbContext(builder.Options);
        }
    }
}