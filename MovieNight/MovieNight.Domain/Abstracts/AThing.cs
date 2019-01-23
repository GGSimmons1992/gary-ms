using MovieNight.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight.Domain.Abstracts
{
    public abstract class AThing: IThing
    {
        public int Id { get; private set; }

        public virtual bool IsValid()
        {
            return (this.Id > 0);
        }
    }
}
