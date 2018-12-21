using System;
using System.Collections.Generic;
using System.Text;

namespace GenericConsole.Library.Models
{
    public class Trainer
    {
        public People<Peep> Trainers { get; set; }

        public Trainer()
        {
            Trainers.Peoples.Add(new Peep("trainer"));
        }
    }
}
