using Microsoft.AspNetCore.Mvc;
using Mission6_Garner.Models;
using System.Diagnostics;

namespace Mission6_Garner.Controllers
{
    public class HomeController : Controller
    {
        // This is the database context
        private readonly MovieDatabaseContext _context;

        public HomeController(MovieDatabaseContext temp)
        {
            _context = temp;
        }  

        
        // This gets the Index page
        public IActionResult Index()
        {
            return View();
        }
        // This gets the About page
        public IActionResult About()
        {
            return View();
        }

        // This gets the Movie form page for the user to fill out
        [HttpGet]
        public IActionResult Movies()
        {
            return View("Movies");
        }

        // This posts to the database and then goes to the confirmation page
        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            _context.Movies.Add(response); // add the movie to the database
            _context.SaveChanges(); // save the changes
            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
