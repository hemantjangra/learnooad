using System;
using DogHouse.Models;

namespace DogHouse.Actions
{
    public class BarkDoor
    {
        private DogDoor _door;
        public BarkDoor(DogDoor dogDoor)
        {
            _door = dogDoor;
        }

        public void Recognize(string bark)
        {
            _door.Open();
        }
    }
}
