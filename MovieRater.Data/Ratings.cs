using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Ratings
    {
        public bool IsReccommended { get; set; }
        public bool IsFamilyFriendly { get; set; }

        [Required]
        public int ActualRating { get; set; }
    }
}
