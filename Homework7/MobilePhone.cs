namespace Homework7
{
    public class MobilePhone : Item, IPhoto
    {
        private double _numberOfPixelsInCamera;
        public double NumberOfPixelsInCamera { get { return _numberOfPixelsInCamera; } set { _numberOfPixelsInCamera = value; } }
        public override string? Description => $"Price: {price}, model:{modelName}, number of pixels in camera: {_numberOfPixelsInCamera}";

        public MobilePhone(string modelName, decimal price, double numberOfPixelsInCamera) : base(modelName, price)
        {
            _numberOfPixelsInCamera = numberOfPixelsInCamera;
        }

        public override void TurnOn()
        {
            Console.WriteLine("Press left side button");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Press button on the screen and photo is ready");
        }
    }
}
