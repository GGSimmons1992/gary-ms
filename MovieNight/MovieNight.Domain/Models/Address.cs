using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class Address : AThing
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }

        public override bool IsValid()
        {
            
            return Validator.ValidateString(this) &&
                this.Country.IsValid();
        }

    }

}
