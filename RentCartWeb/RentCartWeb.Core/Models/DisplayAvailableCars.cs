using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.Core.Models
{
    public class DisplayAvailableCars
    {
        public string CarID { get; set; }
       
        public string Plate { get; set; }
        
        public string Manufacturer { get; set; }
      
        public string Model { get; set; }
        public string LocationCar { get; set; }
        public List<DisplayAvailableCars> userinfo { get; set; }
    }
}
