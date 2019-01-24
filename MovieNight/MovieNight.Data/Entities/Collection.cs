using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Collection
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
