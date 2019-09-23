using System;
using DogHouse.Enums;

namespace DogHouse.Actions
{
    public interface IToggleDoorState
    {
        bool ToggleDoor(GateTriggers gateTrigger);
    }
}
