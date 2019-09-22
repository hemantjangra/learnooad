using System.Collections.Generic;
using HeadFirst.FirstIteration.Models;

namespace HeadFirst.FirstIteration.Interface
{
    public interface IInventory
    {
         void AddGuitar(Guitar guitar);

         Guitar GetGuitar(string serialNumber);

         List<Guitar> SearchGuitar(GuitarSpec guitar);
    }
}