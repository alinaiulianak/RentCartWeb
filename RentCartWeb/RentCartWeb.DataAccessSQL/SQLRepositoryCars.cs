using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCartWeb.Core.Contracts;
using RentCartWeb.Core.Models;
using RentCartWeb.DataAccess.InMemory;
using System.Data.Entity;

namespace RentCartWeb.DataAccessSQL
{
    public class SQLRepositoryCars: ICarRepository
    {
        internal DataContext context;
        internal DbSet<Cars> dbSet;

        public SQLRepositoryCars(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Cars>();

        }
        public IQueryable<Cars> Collection()
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
        public Cars Find(int CarID)
        {
            return dbSet.Find(CarID);
        }
        public void Insert(Cars t)
        {
            dbSet.Add(t);
        }

        public void Update(Cars t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
