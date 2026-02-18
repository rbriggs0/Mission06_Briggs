using System.ComponentModel.DataAnnotations;
namespace Mission06_Briggs.Models
{
    public class Category
    {
        // Primary Key
        public int CategoryId { get; set; }
        // Required field - initialized to empty string to avoid nullable warnings
        [Required]
        public string CategoryName { get; set; } = string.Empty;
	}
}
