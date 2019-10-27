using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentCartWeb.Core.Models
{
    public class Customers
    {   
        public int CostumerID { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        //public Customers()
        //{
        //    this.CostumerID = Guid.NewGuid().ToString();
        //}
    }
}
