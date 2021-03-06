﻿using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class User:AThing
    {
        public Name Name { get;set;}
        public Payment Payment { get; set; }
        public Membership Membership { get; set; }
        public List<Movie> Queue { get; set; }
        public List<Movie> Collection { get; set; }
        public Address Address { get; set; }

        public User()
        {
            (new Library()).OutOfStockNotice += HandleOutOfStockNotice;
            Queue = new List<Movie>();
            Collection = new List<Movie>();
        }

        public override bool IsValid()
        {
            return (Name.IsValid() &&
                Payment.IsValid() &&
                Membership.IsValid() &&
                Address.IsValid());
            
        }

        public bool ReturnMovie(Movie movie, Library lib)
        {
            //var lib = new Library();


            if (lib.Checkin(movie))
            {
                Collection.Remove(movie);
                NextMovie(lib);
                return true;
            }

            return false;
        }

        public void NextMovie(Library lib)
        {
            
            Movie movie=null;

            if (Collection.Count < Membership.Level)
            {
                foreach (var item in Queue)
                {
                    if (lib.Checkout(item.Title))
                    {
                        movie = item;
                        break;
                    }
                }

                if (movie != null)
                {
                    Collection.Add(movie);
                    Queue.RemoveAll(m => m.Title == movie.Title);
                }
            }
            
        }

        private void HandleOutOfStockNotice(OutOfStockArgs args)
        {
            //mangage the queue by moiving out of stock to back of queue
            Console.WriteLine(args.Movie);
        }

    }
}
