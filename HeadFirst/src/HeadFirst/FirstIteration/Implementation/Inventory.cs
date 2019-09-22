using System.Collections.Generic;
using HeadFirst.FirstIteration.Interface;
using System.Linq;
using HeadFirst.FirstIteration.Enums;
using HeadFirst.FirstIteration.Models;

namespace HeadFirst.FirstIteration.Implementation
{
    public class Inventory : IInventory
    {
        private List<Guitar> _guitars;

        public Inventory()
        {
            _guitars = new List<Guitar>();
            FillInventory();
        }
        public void AddGuitar(Guitar guitar)
        {
            _guitars.Add(guitar);
        }

        public Guitar GetGuitar(string serialNumber)
        {
            return _guitars.Where(guitar => guitar.SerialNumber.Equals(serialNumber))?.FirstOrDefault();
        }

        public List<Guitar> SearchGuitar(GuitarSpec requiredGuitar)
        {
            // return _guitars.Where(guitar => guitar.Type.Equals(requiredGuitar.Type) &&
            //                  guitar.Builder.Equals(requiredGuitar.Builder) &&
            //                  guitar.Model.Equals(requiredGuitar.Model) &&
            //                  guitar.BackWood.Equals(requiredGuitar.TopWood) &&
            //                  guitar.TopWood.Equals(requiredGuitar.TopWood) &&
            //                  guitar.NumString.Equals(requiredGuitar.NumString))?.ToList();
            return _guitars.Where(guitar => guitar.GuitarSpec.IsGuitarMatch(requiredGuitar)).ToList();
        }

        private void FillInventory()
        {
            AddGuitar(new Guitar{SerialNumber ="V12345", Price=0 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor", Type=Type.Electric, BackWood=Wood.Alder, TopWood=Wood.Pine}});
            AddGuitar(new Guitar{SerialNumber ="V12346", Price=0 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor", Type=Type.Electric, BackWood=Wood.Alder, TopWood=Wood.Alder, NumString="12"}});
            AddGuitar(new Guitar{SerialNumber ="A21457", Price=0 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="OakTown Goove", Type=Type.Accoustic, BackWood=Wood.Oak, TopWood=Wood.Oak}});
            AddGuitar(new Guitar{SerialNumber ="V95693", Price=1499.95 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor", Type=Type.Electric, BackWood=Wood.Alder, TopWood=Wood.Pine}});
            AddGuitar(new Guitar{SerialNumber ="X54321", Price=0 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor Light", Type=Type.Electric, BackWood=Wood.Cedar, TopWood=Wood.Brazilian_Rosewood}});
            AddGuitar(new Guitar{SerialNumber ="X99876", Price=0 , GuitarSpec = new GuitarSpec{Builder=Builder.Fendor, Model="Stratocastor FeatherWeight", Type=Type.Electric, BackWood=Wood.Brazilian_Rosewood, TopWood=Wood.Alder}});
        }
    }
}