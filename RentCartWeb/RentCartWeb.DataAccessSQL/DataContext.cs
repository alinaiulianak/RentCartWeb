using RentCartWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.DataAccessSQL
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Cars> Cars { get; set; }



    }
}
