﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genere { get; set; }
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")]
       // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")]
        public string? Rating { get; set; }          
    }
}
