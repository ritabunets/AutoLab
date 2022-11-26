namespace Homework9_Lists
{
    public class ListMethods
    {
        public static void AddElementToCollection(List<int> numbers, int ListLength)
        {
            for (int i = 0; i < ListLength; i++)
            {
                try
                {
                    numbers.Add(int.Parse(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Value cannot be added to an int List");
                }
            }
        }

        public static int SumOfEvenNumbers(List<int> numbers)
        {
            int SumOfEvenNumbers = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    SumOfEvenNumbers += number;
                }
            }
            return SumOfEvenNumbers;
        }

        public static void GetWords(int WordLength, List<string> words)
        {
            foreach (string word in words)
            {
                if (word.Length == WordLength)
                {
                    Console.WriteLine(word);
                }
            }
        }

        public static void GetWords(List<string> words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
