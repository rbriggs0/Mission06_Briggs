using Microsoft.EntityFrameworkCore;

namespace Mission06_Briggs.Models
{
	// This class represents the database context
	// It's the "bridge" between your C# code and the SQLite database
	public class MovieContext : DbContext
	{
		// Constructor - required for dependency injection
		public MovieContext(DbContextOptions<MovieContext> options) : base(options)
		{
		}

		// DbSet for Movies table
		public DbSet<Movie> Movies { get; set; }

		// NEW: DbSet for Categories table
		public DbSet<Category> Categories { get; set; }
	}
}