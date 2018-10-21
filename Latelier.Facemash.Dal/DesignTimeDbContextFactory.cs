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
            var connectionString = @"Server = (localdb)\v11.0; Database = FaceMash; Trusted_Connection = True;";
            builder.UseSqlServer(connectionString);
            return new FaceMashDbContext(builder.Options);
        }
    }
}