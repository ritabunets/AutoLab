namespace Homework8_2
{
    public class RealEstateObjectExceptions : Exception
    {
        public RealEstateObjectExceptions(string? address) : base($"Address is not set.")
        {
        }

        public RealEstateObjectExceptions(double square) : base($"Invalid square set. Square:{square}")
        {
        }

        public RealEstateObjectExceptions(int price) : base($"Invalid price set. Price:{price}")
        {
        }
    }
}
