using PizzaStore.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;
using dat = PizzaStore.Data.Models;

namespace PizzaStore.MVCClient.Models
{
    public class LocationUser
    {
        public string Name { get; set; }
        [Required(ErrorMessage ="Select One!")]
        public int StoreId { get; set; }
        public List<dom.Location> AvailableLocations { get; set; }
        public List<dom.Order> History { get; set; }
        public Dictionary<int,string> CrustDictionary { get; set; }

        public LocationUser()
        {
            CrustDictionary = new Dictionary<int, string>();
        }

        public List<dom.Location> GetLocations()
        {
            var domlocations = LocationHelper.GetLocations();
            
            return domlocations;
        }

        public void AssignCrusts()
        {
            foreach (var o in History)
            {
                foreach (var p in o.PizzaList)
                {
                    var datapizza = new dat.Pizza() {PizzaId=p.Id,CrustId=(byte) p.CrustId};
                    CrustDictionary.Add(p.Id, PizzaHelper.GetCrustNameByPizza(datapizza));
                }
            }
        }

    }

}
