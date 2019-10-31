using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccess.InMemory
{
    public class ReservationRepository : IReservationRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Reservations> reservations;

        public ReservationRepository()
        {
            reservations = cache["reservations"] as List<Reservations>;
            if (reservations == null)
            {
                reservations = new List<Reservations>();
            }
        }
        public void Commit()
        {
            cache["reservations"] = reservations;
        }

        public void Insert(Reservations p)
        {
            reservations.Add(p);
        }
        public void Update(Reservations rent)
        {
            Reservations reservationToUpdate = reservations.Find(p => (p.CarID == rent.CarID) && (p.Id == rent.Id) && (p.StartDate == rent.StartDate));

            if (reservationToUpdate != null)
            {
                reservationToUpdate = rent;
            }
            else
            {
                throw new Exception("Reservation not found!");
            }
        }

        public Reservations Find(int CarID, int Id, DateTime StartDate)
        {
            Reservations rent = reservations.Find(p => (p.CarID == CarID) && (p.Id == Id) && (p.StartDate == StartDate));

            if (rent != null)
            {
                return rent;
            }
            else
            {
                throw new Exception("Reservation not found!");
            }
        }

        public IQueryable<Reservations> Collection()
        {
            return reservations.AsQueryable();
        }
    }
}
