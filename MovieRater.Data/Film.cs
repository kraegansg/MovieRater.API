using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int FilmRating { get; set; }

        [Required]
        public int RatingStars { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
