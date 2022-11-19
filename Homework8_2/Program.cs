namespace Homework8_2
{
    class Program
    {
        private static void Main(string[] args)
        {
            RealEstateObject flat1 = new RealEstateObject() { address = "Lithuania, Vilnius", price = 190, square = 48.5 };
            RealEstateObject flat2 = new RealEstateObject() { address = "", price = 190000, square = 48.5};
            RealEstateObject flat3 = new RealEstateObject() { address = "Lithuania, Vilnius", price = 190000, square = 10 };
        }
    }
}