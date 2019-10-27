using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccess.InMemory
{
    public class CarRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Cars> cars;

        public CarRepository()
        {
            cars = cache["cars"] as List<Cars>;
            if (cars == null)
            {
                cars = new List<Cars>();
            }
        }
        public void Commit()
        {
            cache["cars"] = cars;
        }

        public IQueryable<Cars> Collection()
        {
            return cars.AsQueryable();
        }


    }
}
