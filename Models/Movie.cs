using System.ComponentModel.DataAnnotations;

namespace Mission06_Briggs.Models
{
	public class Movie
	{
		// Primary Key
		public int MovieId { get; set; }

		// Required fields - initialized to empty string to avoid nullable warnings
		[Required]
		public string Title { get; set; } = string.Empty;

		[Required]
		public int Year { get; set; }

		[Required]
		public string Director { get; set; } = string.Empty;

		[Required]
		public string Rating { get; set; } = string.Empty;

		// Optional fields
		public bool Edited { get; set; }

		public string? LentTo { get; set; }

		[MaxLength(25)]
		public string? Notes { get; set; }
	}
}