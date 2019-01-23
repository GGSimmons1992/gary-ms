using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight.Domain.Models
{
    public class OutOfStockArgs : EventArgs
    {
        public Movie Movie { get; set; }

        public OutOfStockArgs(Movie m)
        {
            Movie = m;
        }

    }
}
