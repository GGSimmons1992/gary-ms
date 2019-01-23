using MovieNight.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class Payment:AThing
    {
        public long CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int VerificationCode { get; set; }
        public Address Address { get; set; }
        public Name CardHolder { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateNumber(this) && 
                Address.IsValid() && 
                CardHolder.IsValid();
        }
    }
}
