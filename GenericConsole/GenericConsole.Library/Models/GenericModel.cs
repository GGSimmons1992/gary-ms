using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConsole.Library.Models
{
    class GenericModel<T>
    {
        public void Hello()
        {
            Console.WriteLine("I am a generic!");
        }
    }
}
