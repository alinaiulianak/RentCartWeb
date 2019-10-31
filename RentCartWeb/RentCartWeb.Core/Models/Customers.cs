using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RentCartWeb.Core.Models
{
    public class Customers: BaseEntity
    {   
        //public int CostumerID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Enter A Name")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Enter A Valid Birth Date")]
        //[RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid Birth Date Eg: dd-MM-yyyy")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        [StringLength(50)]
        public string ZIPCode { get; set; }

        public string consoleClientID, consoleClientName, consoleBirthDate, consoleZipCode;

        //public List<Customers> userinfo { get; set; }
        //public Customers()
        //{
        //    this.CostumerID = Guid.NewGuid().ToString();
        //}

        //public bool IsZipValid()
        //{
        //    var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        //    if (consoleZipCode == "")
        //    {
        //        txt_Location = "";
        //        return true;
        //    }
        //    else if ((!Regex.Match(consoleZipCode, _usZipRegEx).Success))
        //    {
        //        Console.WriteLine("ZIP Code is not in the correct US format!");
        //        return false;
        //    }
        //    else
        //    {
        //        txt_Location = consoleZipCode;
        //        return true;

        //    }

        //}

    }
}
