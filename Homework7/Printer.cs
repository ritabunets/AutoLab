namespace Homework7
{
    public class Printer : ItemWorkingWithPaper
    {
        public string? Description => $"Price: {price}, model:{modelName}";

        public Printer(string modelName, decimal price, int paperWidth, int paperHeight) : base(modelName, price, paperWidth, paperHeight)
        {
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press button at the top");
        }
    }
}
