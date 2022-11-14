namespace Homework7
{
    public class MobilePhone : Item, IPhoto
    {
        public double numberOfPixelsInCamera;
        public double NumberOfPixelsInCamera { get { return 0; } set { numberOfPixelsInCamera = value; } }
        public string? Description { get { return $"Price: {price}, model:{modelName}, number of pixels in camera: {numberOfPixelsInCamera}"; } }
        public MobilePhone(string modelName, decimal price, double numberOfPixelsInCamera) : base(modelName, price)
        {
            this.numberOfPixelsInCamera = numberOfPixelsInCamera;
        }
        public new void TurnOn()
        {
            Console.WriteLine("Press left side button");
        }
        public void TakePhoto()
        {
            Console.WriteLine("Press button on the screen and photo is ready");
        }
    }
}
