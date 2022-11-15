namespace Homework7
{
    public class Polaroid : ItemWorkingWithPaper, IPhoto
    {
        private double _numberOfPixelsInCamera;
        public double NumberOfPixelsInCamera { get { return _numberOfPixelsInCamera; } set { _numberOfPixelsInCamera = value; } }
        public string? Description => $"Price: {price}, model:{modelName}, number of pixels in camera: {_numberOfPixelsInCamera}";

        public Polaroid(string modelName, decimal price, int paperWidth, int paperHeight, double numberOfPixelsInCamera) : base(modelName, price, paperWidth, paperHeight)
        {
            _numberOfPixelsInCamera = numberOfPixelsInCamera;
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press right side button");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Press black button at the top and photo is ready");
        }
    }
}