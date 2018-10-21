using System;
using System.Collections.Generic;

namespace Latelier.Facemash.Core.Pattern
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="TModel">The Entity</typeparam>
    public interface IRepository<TModel>
    {
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns>List of <see cref="TModel"/></returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// Get item by identifier
        /// </summary>
        /// <returns><see cref="TModel"/></returns>
        TModel GetById(string id);

        /// <summary>
        /// Save an item
        /// </summary>
        /// <param name="model"><see cref="TModel"/></param>
        /// <returns><see cref="TModel"/></returns>
        TModel Save(TModel model);

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>Result</returns>
        bool Delete(string id);
    }
}