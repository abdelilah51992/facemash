using Latelier.Facemash.Dal.Dao;
using Latelier.Facemash.Dal.Interface;
using Latelier.Facemash.Dal.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Latelier.Facemash.Dal
{
    /// <summary>
    /// Face mash Dal service
    /// </summary>
    public class FacemashDalService : IFacemashDalService
    {
        /// <summary>
        /// Gets the cat repository
        /// </summary>
        private readonly ICatRepository _catRepository;

        /// <summary>
        /// Gets the logger
        /// </summary>
        private readonly ILogger<FacemashDalService> _logger;

        /// <summary>
        /// Instantiate the face mash dal service
        /// </summary>
        /// <param name="catRepository">The Cat repository</param>
        /// <param name="logger">The logger</param>
        public FacemashDalService(ICatRepository catRepository,
                                  ILogger<FacemashDalService> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public IEnumerable<Cat> GetAll()
        {
            try
            {
                return _catRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">The idenfier</param>
        /// <returns></returns>
        public Cat GetById(string id)
        {
            try
            {
                return _catRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Save a cat
        /// </summary>
        /// <param name="cat">The Cat</param>
        /// <returns>The Cat</returns>
        public Cat Save(Cat cat)
        {
            try
            {
                _catRepository.Save(cat);
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Vote for th cat
        /// </summary>
        /// <param name="id">The identifier</param>
        public void Vote(string id)
        {
            try
            {
                _catRepository.Vote(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}