using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

		// GET: Displays the empty form
		public IActionResult MovieForm()
		{
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
				return RedirectToAction("Index");
			}

			// If validation failed, show the form again with errors
			return View(movie);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new Mission06.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}