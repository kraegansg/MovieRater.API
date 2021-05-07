using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class FilmCreate
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int RatingStars { get; set; }
    }
}
