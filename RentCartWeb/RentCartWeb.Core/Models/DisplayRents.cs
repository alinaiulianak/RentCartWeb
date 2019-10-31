using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.Core.Models
{
    public class DisplayRents
    {
       
        public string CarID { get; set; }

        
        public string Id { get; set; }
       

        public string StartDate { get; set; }

       
        public string EndDate { get; set; }

      
        public string Location { get; set; }

        public List<DisplayRents> userinfo { get; set; }
    }
}
