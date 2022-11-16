namespace Homework7
{
    public abstract class Item
    {
        protected string? modelName;
        protected decimal price;
        public virtual string? Description => $"Price: {price}, model:{modelName}";

        public Item(string modelName, decimal price)
        {
            this.modelName = modelName;
            this.price = price;
        }

        public abstract void TurnOn();

        public void TunrnOff()
        {
            Console.WriteLine("Press Turn Off button");
        }
    }

    public abstract class ItemWorkingWithPaper : Item
    {
        public int paperWidth;
        public int paperHeight;

        public ItemWorkingWithPaper(string modelName, decimal price, int paperWidth, int paperHeight) : base (modelName, price)
        {
            this.paperWidth = paperWidth;
            this.paperHeight = paperHeight;
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    interface IPhoto
    {
        double NumberOfPixelsInCamera { get; set; }

        public void TakePhoto()
        {
        }
    }
}
