using RentCartWeb.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using RentCartWeb.DataAccess.InMemory;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Caching;

namespace RentCartWeb.Core.Models
{
   public class Reservations 
    {
        [Required(ErrorMessage = "Enter A CarId")]
        [Key, Column(Order = 1)]
        public int CarID { get; set;}

        [Required(ErrorMessage = "Enter A CustomerId")]
        [Key, Column(Order = 2)]
        public int Id { get; set; }
        //public int ReservStatsID { get; set; }

        [Required(ErrorMessage = "Enter A Valid Start Date")]
        [DataType(DataType.Date)]
        [Key, Column(Order = 3)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enter A Valid End Date")]
        [DataType(DataType.Date)]
           public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Enter A City")]
        public string Location { get; set; }
        //public static ValidationResult ValidateCarId(string pNewName, ValidationContext pValidationContext)
        //{
        //    pNewName
        //    //bool IsNotValid = true; // should implement here the database validation logic
        //    //if (IsNotValid)
        //    //    return new ValidationResult("CityCode not recognized", new List<string> { "CityCode" });
        //    //return ValidationResult.Success;
        //}
    }
}
