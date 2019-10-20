using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DBOps.DBContext
{
    public interface IMongoContext : IDisposable
    {
        Task<int> SaveChanges();

        IMongoCollection<T> GetCollection<T>(string name);

        Task AddCommand(Func<Task> command);
    }
}