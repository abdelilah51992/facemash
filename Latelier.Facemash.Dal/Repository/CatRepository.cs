using Latelier.Facemash.Dal.Dao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Latelier.Facemash.Dal.Repository
{
    /// <summary>
    /// Cat Repository
    /// </summary>
    internal class CatRepository : ICatRepository
    {
        /// <summary>
        /// Gets the face mash db context
        /// </summary>
        private readonly FaceMashDbContext _db;

        /// <summary>
        /// Instantiate cat repository
        /// </summary>
        /// <param name="db"></param>
        public CatRepository(FaceMashDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all cats
        /// </summary>
        /// <returns>List of cats</returns>
        public IEnumerable<Cat> GetAll()
        {
            return _db.Cats.ToList();
        }

        /// <summary>
        /// Gets by id
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The Cat</returns>
        public Cat GetById(string id)
        {
            return _db.Cats.Find(id);
        }

        /// <summary>
        /// Save a cat
        /// </summary>
        /// <param name="cat">The cat</param>
        /// <returns>The cat</returns>
        public Cat Save(Cat cat)
        {
            var exit = GetById(cat.Id) != null;

            if (exit)
                _db.Update(cat);
            else
                _db.Add(cat);
            _db.SaveChanges();

            return cat;
        }

        /// <summary>
        /// Vote for a cat
        /// </summary>
        /// <param name="id">The identifier</param>
        public void Vote(string id)
        {
            var cat = GetById(id);
            if (cat != null)
            {
                cat.Score++;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a cat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}