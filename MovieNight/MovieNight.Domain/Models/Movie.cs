using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class Movie: AThing
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Rating Rating { get; set; }
        public TimeSpan Durration { get; set; }
        public string Summary { get; set; }
        public string Imdb { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateString(this) && Rating.IsValid() && Genre.IsValid() && (Durration != null);
        }
    }

    

}
