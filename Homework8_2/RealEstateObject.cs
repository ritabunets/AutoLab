namespace Homework8_2
{
    public class RealEstateObject
    {
        private string? _address;
        private double _square;
        private int _price;
        public string? address
        {
            get => _address;
            set
            {
                if (value.Equals(string.Empty))
                    throw new RealEstateObjectExceptions(value);
                else
                    _address = value;
            }
        }
        public double square
        {
            get => _square;
            set
            {
                if (value < 20)
                    throw new RealEstateObjectExceptions(value);
                else
                    _square = value;
            }
        }
        public int price
        {
            get => _price;
            set
            {
                if (value < 1000)
                    throw new RealEstateObjectExceptions(value);
                else
                    _price = value;
            }
        }
    }
}