using MovieNight.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MovieNight.Testing.UnitTests
{
    public class LibraryTests
    {
        private Library sut;
        public Address Address {get;set;}
        public Dictionary<Movie, int> Content { get; set; }
        public Movie Movie { get; set; }

        public LibraryTests()
        {
            Movie = new Movie()
            {
                Title = "Titanic 2",
                Rating = new Rating() { Name = "NC-17", Description = "Too much romance" },
                Genre = new Genre() { Name = "Horror", Description = "Too much romance" },
                Summary = "did i say horror",
                Durration=new System.TimeSpan(3,0,0),
                Imdb="url"
            };
            sut = new Library();
            Address = new Address()
            {
                Street="3220 Banyan Circle",
                City="Tampa",
                StateProvince="FL",
                Country=new Country() { Name="United States of America", Code="USA"},
                PostalCode="33613"
            };
            Content = new Dictionary<Movie, int>()
            {
                { Movie,10 }
            };
            sut.Address = Address;
            sut.Content = Content;
        }

        [Fact]
        public void Test_IsValid()
        {
            

            Assert.True(sut.IsValid());
        }

        [Fact]
        public void Test_CheckIn()
        {
            var count = sut.Content[Movie];

            
            Assert.True(sut.Checkin(Movie));
            Assert.True(sut.Content.Count ==1 );
        }

        [Fact]
        public void Test_Checkout()
        {
            var count = sut.Content[Movie];
            
            Assert.True(sut.Checkout(Movie.Title));
            Assert.True(sut.Content.Count == 1);
        }

    }
}
