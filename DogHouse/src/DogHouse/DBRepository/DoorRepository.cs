using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBOps.DBContext;
using DBOps.Repository;
using DogHouse.Entities;

namespace DogHouse.DBRepository
{
    public class DoorRepository : BaseRepository<DoorState>, IDoorRepository
    {
        private readonly IMongoContext _mongoContext;
        public DoorRepository(IMongoContext mongoContext) : base(mongoContext)
        {
            _mongoContext = mongoContext;
        }
        public override async Task Add(DoorState doorStateData) => await base.Add(doorStateData);

        public override async Task<IEnumerable<DoorState>> GetAll() => await base.GetAll();

        public override async Task<DoorState> GetById(string id) => await base.GetById(id);

        public override async Task Remove(string id) => await base.Remove(id);

        public override async Task Update(DoorState entity) => await base.Update(entity);
    }
}