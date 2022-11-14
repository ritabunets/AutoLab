namespace Homework7
{
    interface IReadable 
    {
        string? Description { get; }
        void TurnPage();
    }
    interface IRecyclable
    {
        void Recycle();
    }
    internal class Book:IReadable, IRecyclable
    {
        public string? Description { get { return "This is usual book."; } }
        public void TurnPage()
        {
            Console.WriteLine("Page turn sound...");
        }
        public void Recycle()
        {
            Console.WriteLine("Sound of fire crackling...");
        }
    }
    internal class EBook : IReadable, IRecyclable
    {
        public string? Description { get { return "This is electronic book."; } }
        public void TurnPage()
        {
            Console.WriteLine("Page tap sound...");
        }
        public void Recycle()
        {
            Console.WriteLine("Recycling machine sound...");
        }
    }
}
