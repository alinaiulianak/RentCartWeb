using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccess.InMemory
{
    public class CarRepository : ICarRepository
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

        public void Insert(Cars p)
        {
            cars.Add(p);
        }
        public void Update(Cars car)
        {
            Cars carToUpdate = cars.Find(p => p.CarID == car.CarID);

            if (carToUpdate != null)
            {
                carToUpdate = car;
            }
            else
            {
                throw new Exception("Car not found!");
            }
        }

        public Cars Find(int CarID)
        {
            Cars car = cars.Find(p => p.CarID == CarID);

            if (car != null)
            {
                return car;
            }
            else
            {
                throw new Exception("Cars not found!");
            }
        }

        public IQueryable<Cars> Collection()
        {
            return cars.AsQueryable();
        }



    }
}
