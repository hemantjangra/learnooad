using System;
using System.Threading.Tasks;

namespace DogHouse.DoorHelper
{
    public class RemoteOperations : IRemoteOperations
    {
        private readonly IDogDoorOperations _dogDoorOperation;

        public RemoteOperations(IDogDoorOperations dogDoorOperation)
        {
            _dogDoorOperation = dogDoorOperation;
        }
        public async Task PressButton(Guid id) => await _dogDoorOperation.Act(id.ToString());
    }
}