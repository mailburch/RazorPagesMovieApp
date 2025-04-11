using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Range(1, 100)]
        public decimal Price { get; set; }

        public string Rating { get; set; }

        public string Poster { get; set; }

        [Display(Name = "Director")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Director { get; set; } = string.Empty;

    }
}

