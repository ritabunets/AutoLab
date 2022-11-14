namespace Homework7
{
    public class Printer : ItemWorkingWithPaper
    {
        public string? Description { get { return $"Price: {price}, model:{modelName}"; } }
        public Printer(string modelName, decimal price, int paperWidth, int paperHeight) : base(modelName, price, paperWidth, paperHeight)
        {
        }   
        public new void TurnOn()
        {
            Console.WriteLine("Press button at the top");
        }
    }
}
