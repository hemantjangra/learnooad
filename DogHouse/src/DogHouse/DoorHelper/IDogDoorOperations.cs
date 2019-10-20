using System;
using System.Threading.Tasks;
using DogHouse.Models;

namespace DogHouse.DoorHelper
{
    public interface IDogDoorOperations
    {
        Task Act(string id);
        Task<bool> IsOpen(string id);
    }
}