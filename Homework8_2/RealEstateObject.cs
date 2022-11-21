namespace Homework8_2
{
    public class RealEstateObject
    {
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
                    throw new RealEstateObjectExceptions(value);
                else
                    _address = value;
            }
        }

        public double Square
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

        public int Price
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

        public double CalculatePurchaseTax()
        {
            _purchaseTax = _price * _square * 0.0005;
            if (_purchaseTax < 2500)
                throw new Exception($"Tax cannot be less than 2500! Calculated tax is {_purchaseTax}");
            else
                return _purchaseTax;
        }
    }
}