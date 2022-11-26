namespace Homework9_Lists
{
    class ListTasks : ListMethods
    {
        private const int ListLength = 10;
        private const int WordLength = 5;

        public static void Main(string[] args)
        {
            Task1();
            Task2();
            Task2Updated();
        }

        public static void Task1()
        {
            Console.WriteLine("---Task 1:");
            Console.WriteLine($"Type {ListLength} int numbers to create a list:");
            var numbers = new List<int>();
            AddElementToCollection(numbers, ListLength);
            Console.WriteLine("The sum of even numbers is " + SumOfEvenNumbers(numbers));
        }

        public static void Task2()
        {
            Console.WriteLine("---Task 2:");
            Console.WriteLine($"Words with length = {WordLength}:");
            var words = new List<string>() { "ritas", "the", "first", "middle", "last" };
            GetWords(WordLength, words);
        }

        public static void Task2Updated()
        {
            Console.WriteLine("---Task 2 Updated:");
            Console.WriteLine("Enter the length of words from 3 to 6:");
            int _wordLength2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Words with length = {_wordLength2}:");
            var words = new List<string>() { "ritas", "the", "first", "middle", "last" };
            var selectedWords = from w in words
                                where w.Length == _wordLength2
                                select w;
            GetWords(selectedWords.ToList());
        }
    }
}