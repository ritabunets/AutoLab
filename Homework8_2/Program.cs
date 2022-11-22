namespace Homework8_2
{
    class Program
    {
        private static void Main(string[] args)
        {
            RealEstateObject flat1 = new RealEstateObject() { Address = "", Price = 190, Square = 8.5 };
            Console.WriteLine(flat1.CalculatePurchaseTax());
        }
    }
}