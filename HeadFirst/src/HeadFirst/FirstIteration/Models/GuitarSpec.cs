using HeadFirst.FirstIteration.Enums;

namespace HeadFirst.FirstIteration.Models
{
    public class GuitarSpec
    {

        public string Model { get; set; }
        public Type Type { get; set; }
        public Builder Builder { get; set; }
        public Wood BackWood { get; set; }
        public Wood TopWood { get; set; }
        public string NumString { get; set; }

        public bool IsGuitarMatch(GuitarSpec guitarSpec)
        {
            if (Model.Equals(guitarSpec.Model) && Type.Equals(guitarSpec.Type) && Builder.Equals(guitarSpec.Builder) &&
                BackWood.Equals(guitarSpec.BackWood) && TopWood.Equals(guitarSpec.TopWood)
                && NumString.Equals(guitarSpec.NumString))
            {
                return true;
            }
            return false;
        }
    }
}