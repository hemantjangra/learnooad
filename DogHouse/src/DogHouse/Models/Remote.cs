using System;
namespace DogHouse.Models
{
    public class Remote
    {
        private DogDoor _door;
        public Remote(DogDoor dogDoor)
        {
            _door = dogDoor;
        }

        public void PressButton()
        {
            if (_door.IsOpen())
            {
                _door.Close();
            }
            else
            {
                _door.Open();
            }
        }
    }
}
