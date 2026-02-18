using System.ComponentModel.DataAnnotations;

namespace Mission06_Briggs.Models
{
	public class Movie
	{
		// Primary Key
		public int MovieId { get; set; }

		// Required fields
		[Required]
		public string Title { get; set; } = string.Empty;

		[Required]
		[Range(1888, 9999, ErrorMessage = "Year must be 1888 or later")]
		public int Year { get; set; }

		// Nullable - some old movies might have NULL
		public string? Director { get; set; }

		// Nullable - some old movies might have NULL
		public string? Rating { get; set; }

		// Foreign key to Categories table
		[Required]
		public int CategoryId { get; set; }

		// Navigation property
		public Category? Category { get; set; }

		// Required fields (stored as INTEGER: 0 or 1)
		[Required]
		public int Edited { get; set; }

		[Required]
		public int CopiedToPlex { get; set; }

		// Optional fields
		public string? LentTo { get; set; }

		[MaxLength(25)]
		public string? Notes { get; set; }
	}
}