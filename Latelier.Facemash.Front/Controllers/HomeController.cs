using Microsoft.AspNetCore.Mvc;

namespace Latelier.Facemash.Front.Controllers
{
    /// <summary>
    /// home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index action
        /// </summary>
        /// <returns>Result</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The vote action
        /// </summary>
        /// <returns>Result</returns>
        public IActionResult Vote()
        {
            return View();
        }
    }
}