using Microsoft.EntityFrameworkCore;
namespace Mission06_Briggs.Models
{
	// This class represents the database context
	// It's the "bridge" between your C# code and the SQLite database
	public class MovieContext : DbContext
	{
		// Constructor - required for dependency injection
		// This allows the application to automatically create the context when needed
		public MovieContext(DbContextOptions<MovieContext> options) : base(options)
		{
		}

		// DbSet represents a table in the database
		// This creates a "Movies" table with columns based on the Movie model
		public DbSet<Movie> Movies { get; set; }
	}
}