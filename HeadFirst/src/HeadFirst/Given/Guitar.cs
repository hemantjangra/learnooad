namespace HeadFirst.Given
{
    public class Guitar
    {
        internal string serialNumber, builder, model, type, backWood, topWood;

        internal double price;

        public Guitar(string serialNumber, double price, string builder, string model, string type, string backWood, string topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
        }

        public string GetSerialNumber()
        {
            return serialNumber;
        }

        public double GetPrice()
        {
            return price;
        }

        public string GetBuilder()
        {
            return builder;
        }

        public string GetModel()
        {
            return model;
        }

        public string GetGuitarType()
        {
            return type;
        }

        public string GetBackWood()
        {
            return backWood;
        }

        public string GetTopWood()
        {
            return topWood;
        }

    }
}