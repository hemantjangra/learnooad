using System;
using System.Threading.Tasks;
using DBOps.DBContext;

namespace DBOps.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _mongoContext ;

        public UnitOfWork(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }
        public async Task<bool> Commit() => await _mongoContext.SaveChanges() > 0;

        
        public void Dispose()
        {
            _mongoContext?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}