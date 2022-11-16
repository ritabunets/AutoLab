namespace Homework7
{
    class Program
    {
        private static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }

        private static void Task1()
        {
            Console.WriteLine("Task1:");

            ElectroCar eCar = new ElectroCar(brand: "Volkswagen", model: "ID.4", year: 2022, batteryCapacity: 350);
            eCar.DisplayCarDetails();
            eCar.DisplayBatteryCapacity();
            eCar.EngineStart();
            eCar.Move();

            DieselCar dCar = new DieselCar(brand: "Volkswagen", model: "Tiguan", year: 2021, tankCapacity: 70);
            dCar.DisplayCarDetails();
            dCar.DisplayTankCapacity();
            dCar.EngineStart();
            dCar.Move();

            GasolineCar gCar = new GasolineCar(brand: "Volkswagen", model: "Passat", year: 2010, tankCapacity: 60);
            gCar.DisplayCarDetails();
            gCar.DisplayTankCapacity();
            gCar.EngineStart();
            gCar.Move();
        }

        private static void Task2()
        {
            Console.WriteLine("Task2:");

            Book book = new Book();
            Console.WriteLine(book.Description);
            book.TurnPage();
            book.Recycle();

            EBook eBook = new EBook();
            Console.WriteLine(eBook.Description);
            eBook.TurnPage();
            eBook.Recycle();
        }

        private static void Task3()
        {
            Console.WriteLine("Task3:");

            Printer printer = new Printer("Printer-666", 666, 20, 30);
            printer.TurnOn();
            Console.WriteLine(printer.Description);
            printer.Print();
            printer.TunrnOff();

            Polaroid polaroid = new Polaroid("Polaroid 3x", 333, 10, 10, 15);
            polaroid.TurnOn();
            Console.WriteLine(polaroid.Description);
            polaroid.Print();
            polaroid.TunrnOff();

            MobilePhone mobilePhone = new MobilePhone("iMobile 1000 Plus", 1000, 25);
            mobilePhone.TurnOn();
            Console.WriteLine(mobilePhone.Description);
            mobilePhone.TunrnOff();
        }
    }
}