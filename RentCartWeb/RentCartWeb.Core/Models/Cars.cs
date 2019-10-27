using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.Core.Models
{
   public class Cars
    {
        //from int in string, because is more easy to work with string
        public string CarID { get; set; }
       [StringLength(10)]
        public string Plate { get; set; }
        [StringLength(30)]
        public string Manufacturer { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }

        public Cars()
        {
            this.CarID = Guid.NewGuid().ToString();
        }
    }
}
