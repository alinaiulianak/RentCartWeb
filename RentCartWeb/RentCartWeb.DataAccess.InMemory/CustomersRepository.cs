using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using RentCartWeb.Core.Models;


namespace RentCartWeb.DataAccess.InMemory
{
    public class CustomersRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Customers> customers;

        public CustomersRepository()
        {
            customers = cache["customers"] as List<Customers>;
            if (customers == null)
            {
                customers = new List<Customers>;
            }
        }
        public void Commit()
        {
            cache["customers"] = customers;
        }

        public void Insert(Customers c)
        {
            customers.Add(c);
        }
        public void Update(Customers customer)
        {
            Customers customerToUpdate = customers.Find(c => c.CostumerID == customer.CostumerID);

            if (customerToUpdate != null)
            {
                customerToUpdate = customer;
            }
            else
            {
                throw new Exception("Customer not found!");
            }
        }

        public Customers Find(string Id)
        {
            Customers customer = customers.Find(c => c.CostumerID == Id);

            if (customer != null)
            {
                    return customer;
            }
            else
            {
                throw new Exception("Customer not found!");
            }
        }

        public IQueryable<Customers> Collection()
        {
            return customers.AsQueryable();
        }


    }
}
