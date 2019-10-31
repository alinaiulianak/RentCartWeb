using System;
using System.Linq;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccess.InMemory
{
    public interface IReservationRepository
    {
        IQueryable<Reservations> Collection();
        void Commit();
        Reservations Find(int CarID, int Id, DateTime StartDate);
        void Insert(Reservations p);
        void Update(Reservations rent);
    }
}