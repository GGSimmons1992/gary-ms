using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class Membership : AThing
    {
        public int Level { get; set; }
        public decimal Price { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateNumber(this) && Validator.ValidateMoney(this);
        }
    }
}
