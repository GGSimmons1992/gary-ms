using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Library
    {
        public Library()
        {
            Content = new HashSet<Content>();
        }

        public int LibraryId { get; set; }
        public int AddressId { get; set; }

        public virtual LibraryAddress Address { get; set; }
        public virtual ICollection<Content> Content { get; set; }
    }
}
