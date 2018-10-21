using Latelier.Facemash.Core.Pattern;
using Latelier.Facemash.Dal.Dao;

namespace Latelier.Facemash.Dal.Repository
{
    /// <summary>
    /// Cat repository interface
    /// </summary>
    public interface ICatRepository : IRepository<Cat>
    {
        /// <summary>
        /// Vote for a cat
        /// </summary>
        /// <param name="id">The identifier</param>
        void Vote(string id);
    }
}