namespace Homework7
{
    public class Polaroid : ItemWorkingWithPaper, IPhoto
    {
        public double numberOfPixelsInCamera;
        public double NumberOfPixelsInCamera { get { return 0; } set { numberOfPixelsInCamera = value; } }
        public string? Description { get { return $"Price: {price}, model:{modelName}, number of pixels in camera: {numberOfPixelsInCamera}"; } }
        public Polaroid(string modelName, decimal price, int paperWidth, int paperHeight, double numberOfPixelsInCamera) : base(modelName, price, paperWidth, paperHeight)
        {
            this.numberOfPixelsInCamera = numberOfPixelsInCamera;
        }
        public new void TurnOn()
        {
            Console.WriteLine("Press right side button");
        }
        public void TakePhoto()
        {
            Console.WriteLine("Press black button at the top and photo is ready");
        }
    }
}