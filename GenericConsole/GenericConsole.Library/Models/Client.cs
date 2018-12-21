using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConsole.Library.Models
{
    public class Client
    {
        public static readonly People<Peep> Clients = new People<Peep>();

        public Client()
        {
            //Clients = new People<Peep>();
            Clients.Peoples.Add(new Peep("client"));
        }
    }
}
