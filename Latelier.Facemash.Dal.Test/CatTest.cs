using Latelier.Facemash.Dal.Dao;
using Latelier.Facemash.Dal.Interface;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Latelier.Facemash.Dal.Test
{
    /// <summary>
    /// Cat Test Class
    /// </summary>
    public class CatTest
    {
        /// <summary>
        /// Gets the service collection
        /// </summary>
        private readonly IServiceCollection services;

        /// <summary>
        /// Get the face mash Dal Service
        /// </summary>
        private readonly IFacemashDalService _facemashDalService;

        /// <summary>
        /// Ctor
        /// </summary>
        public CatTest()
        {
            services = new ServiceCollection();
            var serviceProvider = services.AddFaceMashDalService()
                   .AddLogging()
                   .BuildServiceProvider();

            _facemashDalService = serviceProvider.GetService<IFacemashDalService>();
        }

        /// <summary>
        /// Test Save Method
        /// </summary>
        [Fact]
        public void SaveMethodTest()
        {
            var cat = new Cat
            {
                Id = "urf23",
                Url = "http://www.image.com",
                Score = 0
            };

            var catResult = _facemashDalService.Save(cat);
            Assert.NotNull(catResult);
        }

        /// <summary>
        /// Test All Method
        /// </summary>
        [Fact]
        public void GetAllMethodTest()
        {
            var cats = _facemashDalService.GetAll();
            Assert.NotNull(cats);
            Assert.NotEmpty(cats);
        }

        /// <summary>
        /// Test Vote method
        /// </summary>
        [Fact]
        public void VoteMethodTest()
        {
            _facemashDalService.Vote("urf23");
            var cat = _facemashDalService.GetById("urf23");
            Assert.NotNull(cat);
            Assert.True(cat.Score > 0);
        }
    }
}