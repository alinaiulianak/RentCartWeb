﻿using System.Linq;
using RentCartWeb.Core.Models;

namespace RentCartWeb.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(int Id);
        T Find(int Id);
        void Insert(T t);
        void Update(T t);
    }
}