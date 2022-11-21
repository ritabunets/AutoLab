namespace Homework8_2
{
    class Program
    {
        private static void Main(string[] args)
        {
            RealEstateObject flat1 = new RealEstateObject() { Address = "Lithuania, Vilnius", Price = 1900, Square = 48.5 };
            Console.WriteLine(flat1.CalculatePurchaseTax());
        }
    }
}