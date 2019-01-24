using MovieNight.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MovieNight.Testing.UnitTests
{
    public class UserTests
    {
        private User Sut;
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Payment Payment { get; set; }
        public Membership Membership { get; set; }
        public Movie Movie { get; set; }
        public Library Library { get; set; }
        public Dictionary<Movie, int> Content { get; set; }

        public UserTests()
        {
            Name = new Name()
            {
                Title = new Prefix()
                {
                    Name = "Ms."
                },
                First = "Reva",
                Last = "Comics"
            };
            Address = new Address()
            {
                Street = "3220 Banyan Circle",
                City = "Tampa",
                StateProvince = "FL",
                Country = new Country() { Name = "United States of America", Code = "USA" },
                PostalCode = "33613"
            };
            Payment = new Payment
            {
                Address = Address,
                CardHolder = Name,
                CardNumber = 1000200030004000,
                Month = 1,
                Year = 22,
                VerificationCode = 567
            };

            Membership = new Membership() { Level = 3, Price = 9.9M };

            Movie = new Movie()
            {
                Title = "Titanic",
                Rating = new Rating() { Name = "NC-17", Description = "Too much romance" },
                Genre = new Genre() { Name = "Horror", Description = "Too much romance" },
                Summary = "did i say horror",
                Durration = new System.TimeSpan(3, 0, 0),
                Imdb = "url"
            };

            Sut = new User()
            {
                Name = Name,
                Payment = Payment,
                Membership = Membership,
                Address = Address
            };
            Sut.Collection.Add(Movie);
            Sut.Queue.Add(Movie);

            Content = new Dictionary<Movie, int>()
            {
                { Movie,10 }
            };

            Library = new Library();
            Library.Content = Content;

        }

        [Fact]
        public void Test_IsValid()
        {
            Assert.True(Sut.IsValid());
        }
        [Fact]
        public void Test_ReturnMovie()
        {
            Assert.True(Sut.ReturnMovie(Movie,Library));
            Assert.True(Sut.Collection.Count == 1);
            Assert.True(Sut.Queue.Count == 0);
        }
    }
}
