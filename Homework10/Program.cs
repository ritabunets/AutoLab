namespace Homework10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var woman = new GenericArray<Woman>(2);
            var men = new GenericArray<Man>(1);

            GenerateElements(2, woman);
            woman.RemoveElement(0);
            var womenString = woman.ToString();
            Console.WriteLine(womenString);

            GenerateElements(1, men);
            var menString = men.ToString();
            Console.WriteLine(menString);
        }

        public static void GenerateElements<T>(int numberOfElements, GenericArray<T> generatedElements) where T : Human, new()
        {
            string? fname;
            string? lname;
            for (int i = 0; i < numberOfElements; i++)
            {
                Console.WriteLine("Set first name:");
                fname = Console.ReadLine();
                Console.WriteLine("Set last name:");
                lname = Console.ReadLine();
                var human = new T();
                human.FName = fname;
                human.LName = lname;
                generatedElements.AddElement(human);
            }
        }
    }
}