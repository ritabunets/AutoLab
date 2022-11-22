namespace Homework8_2
{
    public class RealEstateObject
    {
        private const double MinSquare = 25.5;
        private const double MinPrice = 1000;
        private string? _address;
        private double _square;
        private int _price;
        private double _purchaseTax;

        public string? Address
        {
            get => _address;
            set
            {
                if (value.Equals(string.Empty))
                {
                    throw new RealEstateObjectExceptions();
                }
                    _address = value;
            }
        }

        public double Square
        {
            get => _square;
            set
            {
                if (MinSquare > value)
                {
                    throw new RealEstateObjectExceptions(MinSquare, value);
                }
                    _square = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (MinPrice > value)
                {
                    throw new RealEstateObjectExceptions(MinPrice, value);
                }
                    _price = value;
            }
        }

        public double CalculatePurchaseTax()
        {
            _purchaseTax = _price * _square * 0.0005;
            if (_purchaseTax < 2500)
            {
                throw new Exception($"Tax cannot be less than 2500! Calculated tax is {_purchaseTax}");
            }
                return _purchaseTax;
        }
    }
}