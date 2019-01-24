using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Rating
    {
        public Rating()
        {
            Movie = new HashSet<Movie>();
        }

        public int RatingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
