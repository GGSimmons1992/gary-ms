using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConsole.Library.Models
{
    public class Employee<T>
    {
        public static readonly People<Peep> Employees = new People<Peep>();

        public Employee()
        {
            //Clients = new People<Peep>();
            Employees.Peoples.Add(new Peep(typeof(T).Name));
        }
    }
}
