namespace Homework8_2
{
    public class RealEstateObjectExceptions : Exception
    {
        private string? _address;
        private double _square;
        private int _price;

        public RealEstateObjectExceptions(string? address) : base($"Address is not set.")
        {
            _address = address;
        }
        public RealEstateObjectExceptions(double square) : base($"Invalid square set. Square:{square}")
        {
            _square = square;
        }
        public RealEstateObjectExceptions(int price) : base($"Invalid price set. Price:{price}")
        {
            _price = price;
        }
    }
}
