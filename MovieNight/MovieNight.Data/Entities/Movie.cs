using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            Collection = new HashSet<Collection>();
            Content = new HashSet<Content>();
            Queue = new HashSet<Queue>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int RatingId { get; set; }
        public string Summary { get; set; }
        public TimeSpan Duration { get; set; }
        public string Imdb { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual ICollection<Collection> Collection { get; set; }
        public virtual ICollection<Content> Content { get; set; }
        public virtual ICollection<Queue> Queue { get; set; }
    }
}
