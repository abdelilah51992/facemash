using Latelier.Facemash.Dal.Dao;
using Latelier.Facemash.Dal.Interface;
using Latelier.Facemash.Front.Helper;
using Latelier.Facemash.Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Latelier.Facemash.Front.Controllers
{
    /// <summary>
    /// Cat Controller
    /// </summary>
    [Route("api/[controller]")]
    public class CatController : Controller
    {
        /// <summary>
        /// Get the face mash Dal service
        /// </summary>
        private readonly IFacemashDalService _facemashDalService;

        /// <summary>
        /// Gets the logger
        /// </summary>
        private readonly ILogger<CatController> _logger;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="facemashDalService"></param>
        public CatController(IFacemashDalService facemashDalService,
            ILogger<CatController> logger)
        {
            _facemashDalService = facemashDalService;
            _logger = logger;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List of cats</returns>
        [HttpGet("all")]
        public List<Cat> GetAll()
        {
            try
            {
                var cats = _facemashDalService.GetAll().OrderByDescending(a => a.Score).ToList();

                if (cats == null || !cats.Any())
                {
                    cats = Initialize();
                }

                return cats;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Vote for a cat
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Result</returns>
        [HttpPost("vote/{id}")]
        public IActionResult Vote(string id)
        {
            try
            {
                _facemashDalService.Vote(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Initilize Method
        /// </summary>
        /// <returns></returns>
        private List<Cat> Initialize()
        {
            try
            {
                var client = new WebClient();
                var content = client.DownloadString("https://latelier.co/data/cats.json");
                var json = JsonConvert.DeserializeObject<LatelierJson>(content);
                var cats = json.images.ToCats();

                if (cats != null && cats.Any())
                {
                    foreach (var cat in cats)
                        _facemashDalService.Save(cat);
                }
                return cats;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}