using Latelier.Facemash.Dal.Dao;
using System.Collections.Generic;

namespace Latelier.Facemash.Dal.Interface
{
    /// <summary>
    /// Face mash Dal service interface
    /// </summary>
    public interface IFacemashDalService
    {
        /// <summary>
        /// Save a cat
        /// </summary>
        /// <param name="cat">The cat</param>
        /// <returns>The cat</returns>
        Cat Save(Cat cat);

        /// <summary>
        /// Save a cat
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The cat</returns>
        Cat GetById(string id);

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        IEnumerable<Cat> GetAll();

        /// <summary>
        /// Vote for a cat
        /// </summary>
        /// <param name="id"></param>
        void Vote(string id);
    }
}