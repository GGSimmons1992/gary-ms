using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class Library: AThing
    {
        

        public delegate void OutOfStock(OutOfStockArgs args);
        public event OutOfStock OutOfStockNotice;

        public Dictionary<Movie, int> Content {get;set;}
        public Address Address { get; set; }

        public override bool IsValid()
        {
            return (Content != null) && Address.IsValid();
        }

        public bool Checkin(Movie movie)
        {
            var key = Content.Keys.FirstOrDefault(m => m.Title.ToLower() == movie.Title.ToLower());

            if (key == null)
            {
                return false;
            }

            Content[key] += 1;

            return true;
        }

        public bool Checkout(string movieTitle)
        {

            var key=Content.Keys.FirstOrDefault(m => m.Title.ToLower() == movieTitle.ToLower());

            if (key == null)
            {
                return false;
            }

            if (Content[key] == 0)
            {
                ZeroStockNotification();
                return false;
            }


            Content[key] -= 1;

            return true;
        }

        private void ZeroStockNotification()
        {
            foreach (var item in Content)
            {
                if (item.Value == 0)
                {
                    var args = new OutOfStockArgs(item.Key);
                    OutOfStockNotice(args);
                }
            }
        }
    }
}
