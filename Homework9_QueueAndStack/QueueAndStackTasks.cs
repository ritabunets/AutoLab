namespace Homework9_QueueAndStack
{
    class QueueAndStackTasks : QueueAndStackMethods
    {
        private const int ListLength = 7;
        private const int NumberOfChars = 3;

        public static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        public static void Task1()
        {
            Console.WriteLine("---Task 1:");
            Console.WriteLine($"Type {ListLength} int numbers to create a queue:");
            Queue<int> numbers = new Queue<int>();
            AddElementToQueue(numbers, ListLength);
            GetMaxValue(numbers);
        }

        public static void Task2()
        {
            Console.WriteLine("---Task 2:");
            Console.WriteLine($"Type {NumberOfChars} chars:");
            Stack<char> chars = new Stack<char>();
            AddElementToStack(chars, NumberOfChars);
            GetStackElements(chars);
        }
    }
}