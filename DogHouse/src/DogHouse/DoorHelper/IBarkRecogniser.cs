using System.Threading.Tasks;
using DogHouse.Entities;

namespace DogHouse.DoorHelper
{
    public interface IBarkRecogniser
    {
         Task<bool> IsAllowedBark(string id, string bark);
    }
}