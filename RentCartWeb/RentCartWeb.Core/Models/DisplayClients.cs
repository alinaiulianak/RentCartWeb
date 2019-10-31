﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.Core.Models
{
    public class DisplayClients
    {
        public string Id { get; set; }
        public string Name { get; set; }
       
        public string BirthDate { get; set; }


        public string Location { get; set; }

        public List<DisplayClients> userinfo { get; set; }
    }
}
