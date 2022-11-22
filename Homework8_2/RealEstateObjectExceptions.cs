namespace Homework8_2
{
    public class RealEstateObjectExceptions : Exception
    {
        private const string? ValueIsNullMessage = "Value cannot be null";

        public RealEstateObjectExceptions() : base(ValueIsNullMessage)
        {
        }

        public RealEstateObjectExceptions(double minSquere, double square) : base($"Min square is {minSquere}. {square} was set.")
        {
        }

        public RealEstateObjectExceptions(int minPrice, int price) : base($"Min price is {minPrice}. {price} was set.")
        {
        }
    }
}
