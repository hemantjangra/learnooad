using System;

namespace DogHouse.Entities
{
    public class DoorState
    {
        public string Id { get; set; }
        public bool Open { get; set; }
        public Bark Barks { get; set; }
    }
}