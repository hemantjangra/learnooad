using System;
using System.Threading.Tasks;

namespace DogHouse.DoorHelper
{
    public interface IBarkOperations
    {
         Task Bark(Guid id);
    }
}