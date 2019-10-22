using System;
using System.Linq;
using System.Threading.Tasks;
using DogHouse.DBRepository;
using DogHouse.Entities;

namespace DogHouse.DoorHelper
{
    public class BarkRecogniser : IBarkRecogniser
    {
        private readonly IDoorRepository _doorDbRepository;
        public BarkRecogniser(IDoorRepository doorDbRepository)
        {
            _doorDbRepository = doorDbRepository;
        }
        public async Task<bool> IsAllowedBark(string id, string sound)
        {
            var result = await _doorDbRepository.GetById(id.ToString());
            if (result is null || result.Barks is null || result.Barks.AllowedBark is null) return false;
            if (result.Barks.AllowedBark.Any(bark => bark.Equals(sound, StringComparison.CurrentCultureIgnoreCase))) return true;
            return false;
        }
    }
}