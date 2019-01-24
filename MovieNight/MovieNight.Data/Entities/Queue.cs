using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Queue
    {
        public int QueueId { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
