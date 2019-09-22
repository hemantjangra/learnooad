using HeadFirst.FirstIteration.Enums;
using HeadFirst.FirstIteration.Models;

namespace HeadFirst.FirstIteration.Models
{
    public class Guitar
    {
        public Guitar()
        {
            this.GuitarSpec = new GuitarSpec();
        }
        public string SerialNumber { get; set; }
        public double Price { get; set; }
        public GuitarSpec GuitarSpec { get; set; }
    }
}