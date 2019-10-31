using System.Linq;
using RentCartWeb.Core.Models;

namespace RentCartWeb.DataAccess.InMemory
{
    public interface ICarRepository
    {
        IQueryable<Cars> Collection();
        void Commit();
        Cars Find(int CarID);
        void Insert(Cars p);
        void Update(Cars car);
    }
}