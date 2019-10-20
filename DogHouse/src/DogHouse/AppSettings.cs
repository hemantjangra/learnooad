namespace DogHouse
{
    public class AppSettings
    {
        public virtual MongoSettings MongoSettings { get; set; }
        public virtual int DoorCloseTime { get; set; }
    }

    public class MongoSettings
    {
        public virtual string ConnectionString { get; set; }
        public virtual string DataBaseName { get; set; }
    }
}
