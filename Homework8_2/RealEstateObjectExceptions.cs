namespace Homework8_2
{
    public class RealEstateObjectExceptions : Exception
    {
        private double _minSquere;
        private double _minPrice;

        public RealEstateObjectExceptions() : base($"Address is not set.")
        {
        }

        public RealEstateObjectExceptions(double minSquere, double square) : base($"Min square is {minSquere}. {square} was set.")
        {
            _minSquere = minSquere;
        }

        public RealEstateObjectExceptions(int minPrice, int price) : base($"Min price is {minPrice}. {price} was set.")
        {
            _minPrice = minPrice;
        }
    }
}
