using System;
using System.Linq;
using System.Threading.Tasks;
using DogHouse.DBRepository;

namespace DogHouse.DoorHelper
{
    public class BarkOperations : IBarkOperations
    {
        private readonly IDogDoorOperations _dogDoorOps;
        private readonly IBarkRecogniser _barkRecogniser;
        public BarkOperations(IDogDoorOperations dogDoorOps, IBarkRecogniser barkRecogniser)
        {
            _dogDoorOps = dogDoorOps;
            _barkRecogniser = barkRecogniser;
        }
        public async Task Bark(Guid id, string sound)
        {
            var isSoundAllowed = await _barkRecogniser.IsAllowedBark(id.ToString(), sound);
            if(isSoundAllowed)
            {
                await _dogDoorOps.Act(id.ToString());
            }
        }
    }
}