using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class TV
    {
        [Key]
        public int TvId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Channel { get; set; }
        public string Genre { get; set; }
        public int TvRating { get; set; }

        [Required]
        public int RatingStars { get; set; }
    }
}
