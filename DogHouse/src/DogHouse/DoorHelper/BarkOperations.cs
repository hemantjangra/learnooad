using System;
using System.Threading.Tasks;

namespace DogHouse.DoorHelper
{
    public class BarkOperations : IBarkOperations
    {
        private readonly IDogDoorOperations _dogDoorOps;
        public BarkOperations(IDogDoorOperations dogDoorOps)
        {
            _dogDoorOps = dogDoorOps;   
        }
        public async Task Bark(Guid id) => await _dogDoorOps.Act(id.ToString());
    }
}