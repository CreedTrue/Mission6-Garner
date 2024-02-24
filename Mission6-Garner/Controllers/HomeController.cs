using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // This gets the list of categories from the database
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            // Then opens the add a movie form and creates a Movie object
            return View("Movies", new Movie());
        }

        // This posts to the database and then goes to the confirmation page
        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            // This checks if the model is valid
            if (ModelState.IsValid)
            {
                _context.Add(response); // add the movie to the database
                _context.SaveChanges(); // save the changes
                return View("Confirmation");
            }
            else
            {
                // This returns the form with the Validation messages
                ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
                return View(response);
            }
            
        }
        public IActionResult MovieList()
        {
            // This gets the list of movies from the database
            // This also includes the category for each movie
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // This gets the movie from the database via the MovieId that is passed from the get
            var movie = _context.Movies.Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            // This updates the movie in the database via the MovieId that is passed from the post
            _context.Movies.Update(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // This gets the movie from the database via the MovieId that is passed from the get
            var movie = _context.Movies.Single(x => x.MovieId == id);
            return View("Delete", movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            // This removes the movie from the database via the MovieId that is passed from the post
            _context.Movies.Remove(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }


        // This gets the error page
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
