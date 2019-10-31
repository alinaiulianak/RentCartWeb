using RentCartWeb.Core.Contracts;
using RentCartWeb.Core.Models;
using RentCartWeb.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.DataAccessSQL
{
    public class SQLRepositoryRent : IReservationRepository
    {
        internal DataContext context;
        internal DbSet<Reservations> dbSet;

        public SQLRepositoryRent(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Reservations>();

        }
        public IQueryable<Reservations> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
        //public void Delete(int Id)
        //{
        //    var t = Find(Id);
        //    if (context.Entry(t).State == EntityState.Detached)
        //    {
        //        dbSet.Attach(t);
        //    }
        //    dbSet.Remove(t);

        //}
        public Reservations Find(int CarID, int Id, DateTime StartDate)
        {
            return dbSet.Find(CarID, Id, StartDate);
        }
        public void Insert(Reservations t)
        {
            dbSet.Add(t);
        }

        public void Update(Reservations t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
