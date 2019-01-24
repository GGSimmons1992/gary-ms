using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public string CardHolder { get; set; }
        public decimal? CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int VerificationCode { get; set; }

        public virtual User User { get; set; }
    }
}
