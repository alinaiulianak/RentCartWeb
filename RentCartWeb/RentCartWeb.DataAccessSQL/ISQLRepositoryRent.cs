using System;
using System.Linq;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccessSQL
{
    public interface ISQLRepositoryRent
    {
        IQueryable<Reservations> Collection();
        void Commit();
        Reservations Find(int IdCar, int Cust, DateTime dt);
        void Insert(Reservations t);
        void Update(Reservations t);
    }
}