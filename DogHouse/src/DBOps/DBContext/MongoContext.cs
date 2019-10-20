using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace DBOps.DBContext
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        private IClientSession _session;

        private MongoClient _mongoClient;

        private readonly List<Func<Task>> _commandTasks;

        public MongoContext(string connectionString, string dbName)
        {
            _commandTasks = new List<Func<Task>>();
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            RegisterConventions();
            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(dbName);
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true)
            };
            ConventionRegistry.Register("HeadFirstConventions", pack, _ => true);
        }

        public async Task<int> SaveChanges()
        {
            using (_session = await _mongoClient.StartSessionAsync())
            {
                _session.StartTransaction();
                var commandTasks = _commandTasks.Select(c => c());
                await Task.WhenAll(commandTasks);
                await _session.CommitTransactionAsync();
            }
            return _commandTasks.Count();
        }

        public IMongoCollection<T> GetCollection<T>(string name) => _mongoDatabase.GetCollection<T>(name);

        public Task AddCommand(Func<Task> command)
        {
            _commandTasks.Add(command);
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            _session?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}