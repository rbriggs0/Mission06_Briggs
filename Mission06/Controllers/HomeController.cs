using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Briggs.Models;

namespace Mission06_Briggs.Controllers
{
	public class HomeController : Controller
	{
		// Database context - gives us access to the database
		private readonly MovieContext _context;

		// Constructor - automatically receives the database context
		// This is called "dependency injection"
		public HomeController(MovieContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetToKnowJoel()
		{
			return View();
		}

		// GET: Display list of all movies
		public IActionResult Movies()
		{
			// Get all movies from database, including their category info
			var movies = _context.Movies
				.Include(m => m.Category) // Join with Categories table
				.OrderBy(m => m.Title)     // Sort alphabetically by title
				.ToList();

			return View(movies);
		}

		// GET: Displays the empty form
		public IActionResult MovieForm()
		{
			// Load categories for the dropdown
			ViewBag.Categories = _context.Categories.ToList();
			return View();
		}

		// POST: Handles form submission and saves to database
		[HttpPost]
		public IActionResult MovieForm(Movie movie)
		{
			// Check if all required fields are valid
			if (ModelState.IsValid)
			{
				// Add the movie to the database
				_context.Movies.Add(movie);

				// Save changes to the database
				_context.SaveChanges();

				// Redirect back to home page after saving
				return RedirectToAction("Movies");
			}

			// If validation failed, show the form again with errors
			ViewBag.Categories = _context.Categories.ToList();  // ? Also add this line!
			return View(movie);
		}

		// GET: Display edit form for a specific movie
		public IActionResult Edit(int id)
		{
			// Find the movie by ID
			var movie = _context.Movies.Find(id);

			// If movie doesn't exist, return 404
			if (movie == null)
			{
				return NotFound();
			}

			// Load categories for dropdown
			ViewBag.Categories = _context.Categories.ToList();

			return View(movie);
		}

		// POST: Save the edited movie
		[HttpPost]
		public IActionResult Edit(Movie movie)
		{
			if (ModelState.IsValid)
			{
				// Update the movie in the database
				_context.Movies.Update(movie);
				_context.SaveChanges();

				// Redirect back to movie list
				return RedirectToAction("Movies");
			}

			// If validation failed, reload categories and show form again
			ViewBag.Categories = _context.Categories.ToList();
			return View(movie);
		}

		// GET: Display delete confirmation page
		public IActionResult Delete(int id)
		{
			// Find the movie by ID
			var movie = _context.Movies
				.Include(m => m.Category)  // Include category info for display
				.FirstOrDefault(m => m.MovieId == id);

			// If movie doesn't exist, return 404
			if (movie == null)
			{
				return NotFound();
			}

			return View(movie);
		}

		// POST: Actually delete the movie
		[HttpPost]
		[ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			// Find the movie
			var movie = _context.Movies.Find(id);

			if (movie != null)
			{
				// Remove from database
				_context.Movies.Remove(movie);
				_context.SaveChanges();
			}

			// Redirect back to movie list
			return RedirectToAction("Movies");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new Mission06.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}