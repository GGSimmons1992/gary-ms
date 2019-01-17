using MVCWorld.Client.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWorld.Client.Models
{
    public class Invitation
    {
        [StringValidator(ErrorMessage="only alpha characters please")]
        [MaxLength(25,ErrorMessage="No more the 25 characters")]
        //[DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        [Range(0,5,ErrorMessage="No more than 5 please")]
        public int Guests { get; set; }

        [Display(Name = "GlutenOption")]
        public string Menu { get; set; }

        //[RsvpValidation()]
        public bool RSVP { get; set; }
        public string Message { get; set; }
    }
}
