using System;
using System.Collections.Generic;

namespace GenericConsole.Library.Models
{
    public class People<T> where T : APerson
    {
        public List<T> Peoples { get; set; }

        public People()
        {
            Peoples = new List<T>();
        }

    }

}
