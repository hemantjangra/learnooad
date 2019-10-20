using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBOps.DBContext;
using MongoDB.Driver;
using ServiceStack;

namespace DBOps.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoContext _dbContext;
        private readonly IMongoCollection<TEntity> _dbSet;

        public BaseRepository(IMongoContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task Add(TEntity entityData)
        {
            await _dbContext.AddCommand(async () => await _dbSet.InsertOneAsync(entityData));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var results = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return results.ToList();
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var result = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return await result.SingleOrDefaultAsync();
        }

        public virtual async Task Remove(string id)
        {
            await _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
        }

        public virtual async Task Update(TEntity entity)
        {
            await _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        public void Dispose()
        {
            _dbContext?.Dispose();
             GC.SuppressFinalize(this);
        }
        #endregion

    }
}