using System.Collections.Generic;

namespace HeadFirst.Given
{
    public class Inventory
    {
        internal List<Guitar> _guitars;

        public Inventory()
        {
            _guitars = new List<Guitar>();
        }

        public List<Guitar> AddGuitar(string serialNumber, double price, string builder, string model, string type,
        string backWood, string topWood)
        {
            Guitar guitar = new Guitar(serialNumber, price, builder, model, type, backWood, topWood);
            _guitars.Add(guitar);
            return _guitars;
        }

        public Guitar GetGuitar(string serialNumber){
            foreach(var guitar in _guitars){
                if(guitar.GetSerialNumber().Equals(serialNumber))
                return guitar;
            }
            return null;
        }

        public Guitar SearchGuitar(Guitar searchGuitar){
            foreach(var guitar in _guitars){
                if(!StringsMatch(searchGuitar.GetBuilder(), guitar.GetBuilder()))
                    continue;
                if(!StringsMatch(searchGuitar.GetModel(), guitar.GetModel()))
                    continue;
                if(!StringsMatch(searchGuitar.GetGuitarType(), guitar.GetGuitarType()))
                    continue;
                if(!StringsMatch(searchGuitar.GetBackWood(), guitar.GetBackWood()))
                    continue;
                if(!StringsMatch(searchGuitar.GetTopWood(), searchGuitar.GetTopWood()))
                    continue;
            }
            return null;
        }

        private bool StringsMatch(string stringA, 
                                  string stringB)
        {
            if (!string.IsNullOrEmpty(stringA) &&
                !string.IsNullOrEmpty(stringB) &&
                string.Compare(stringA, stringB) == 0)
            {
                return true;
            }
            return false;
        }
    }
}