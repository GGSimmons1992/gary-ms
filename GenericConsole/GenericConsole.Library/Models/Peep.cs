using System;

namespace GenericConsole.Library.Models
{
    public class Peep : APerson
    {
        public Peep(string title="anon")
        {
            Name = Guid.NewGuid().ToString();
            Title = title;
        }
    }
}