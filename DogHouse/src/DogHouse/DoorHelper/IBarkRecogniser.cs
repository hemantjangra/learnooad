using DogHouse.Models;

namespace DogHouse.DoorHelper
{
    public interface IBarkRecogniser
    {
         void Recognize(Bark bark);
    }
}