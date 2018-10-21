using Latelier.Facemash.Dal.Dao;
using Microsoft.EntityFrameworkCore;

namespace Latelier.Facemash.Dal
{
    /// <summary>
    /// Face mash db context
    /// </summary>
    public class FaceMashDbContext : DbContext
    {
        /// <summary>
        /// Instantiate db context
        /// </summary>
        public FaceMashDbContext(DbContextOptions<FaceMashDbContext> options)
             : base(options)
        { }

        /// <summary>
        /// Gets the cat dbset
        /// </summary>
        public DbSet<Cat> Cats { get; set; }
    }
}