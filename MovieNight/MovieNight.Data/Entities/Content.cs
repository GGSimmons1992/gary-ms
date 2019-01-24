using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public int LibraryId { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }

        public virtual Library Library { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
