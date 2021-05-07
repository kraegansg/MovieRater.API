using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Model
{
    public class RatingEdit
    {
            public string Title { get; set; }
            public int FilmId { get; set; }
            public int TVId { get; set; }
            public int CurrentRating { get; set; }
    }
}
