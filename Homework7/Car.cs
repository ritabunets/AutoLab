namespace Homework7
{
    public abstract class Car
    {
        public string? brand;
        public string? model;
        public int year;
        public Car(string brand, string model, int year)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
        }
        public abstract int Speed { get; set; }
        public abstract void EngineStart();
        public void DisplayCarDetails()
        {
            Console.WriteLine($"{brand} {model} {year}");
        }
        public void Move()
        {
            Console.WriteLine("Wrooom!");
        }
    }
    public class ElectroCar : Car
    {        
        public int batteryCapacity;
        private int speed;
        public ElectroCar (string brand, string model, int year, int batteryCapacity) : base (brand, model, year)
        {
            this.batteryCapacity = batteryCapacity;
        }
        public override int Speed { get { return 0; } set { speed = value; } }
        public override void EngineStart()
        {
            Console.WriteLine("Electric engine in started!");
        }
        public void DisplayBatteryCapacity()
        {
            Console.WriteLine($"Battery capacity is {batteryCapacity}km");
        }
    }
    public class DieselCar : Car
    {
        public int tankCapacity;
        private int speed;
        public DieselCar(string brand, string model, int year, int tankCapacity) : base(brand, model, year)
        {
            this.tankCapacity = tankCapacity;
        }
        public override int Speed { get { return 0; } set { speed = value; } }
        public override void EngineStart()
        {
            Console.WriteLine("Diesel engine in started!");
        }
        public void DisplayTankCapacity()
        {
            Console.WriteLine($"Tank capacity is {tankCapacity}l");
        }
    }
    public class GasolineCar : Car
    {
        public int tankCapacity;
        private int speed;
        public GasolineCar(string brand, string model, int year, int tankCapacity) : base(brand, model, year)
        {
            this.tankCapacity = tankCapacity;
        }
        public override int Speed { get { return 0; } set { speed = value; } }
        public override void EngineStart()
        {
            Console.WriteLine("Gasoline engine in started!");
        }
        public void DisplayTankCapacity()
        {
            Console.WriteLine($"Tank capacity is {tankCapacity}l");
        }
    }
}
