using System;
using System.Xml.Linq;

namespace Homework10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var woman = new GenericArray<Woman>(2);
            var man = new GenericArray<Man>(1);

            GenerateElements(2, woman);
            GenericArray<Woman>.ToString(woman);

            GenerateElements(1, man);
            GenericArray<Man>.ToString(man);
        }

        public static void GenerateElements<T>(int numberOfElements, GenericArray<T> generatedElements) where T : Human, new()
        {
            string FName;
            string LName;
            for (int i = 0; i < numberOfElements; i++)
            {
                Console.WriteLine("Set first name:");
                FName = Console.ReadLine();
                Console.WriteLine("Set last name:");
                LName = Console.ReadLine();
                var human = new T();
                human.FName = FName;
                human.LName = LName;
                if (typeof(T) == typeof(Woman))
                {
                    generatedElements.AddElement(i, human);
                }
                else if (typeof(T) == typeof(Man))
                {
                    generatedElements.AddElement(i, human);
                }
            }

        }
    }
}