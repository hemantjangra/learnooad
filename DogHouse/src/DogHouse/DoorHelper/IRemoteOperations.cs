using System;
using System.Threading.Tasks;

namespace DogHouse.DoorHelper
{
    public interface IRemoteOperations
    {
         Task PressButton(Guid id);
    }
}