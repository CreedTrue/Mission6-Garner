using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Garner.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage ="A Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="A Year is required")]
        public int Year { get; set; } = 1888;
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage ="An editied value is required")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage ="A Copied To Plex value must be selected")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25, ErrorMessage = "The max Note length is 25 characters")]
        public string? Notes { get; set; }
    }
}
