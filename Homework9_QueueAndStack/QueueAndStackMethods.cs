namespace Homework9_QueueAndStack
{
    public class QueueAndStackMethods
    {
        public static void AddElementToQueue(Queue<int> numbers, int ListLength)
        {
            for (int i = 0; i < ListLength; i++)
            {
                try
                {
                    numbers.Enqueue(int.Parse(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Value cannot be added to an int Queue");
                }
            }
        }

        public static void GetMaxValue(Queue<int> numbers)
        {
            Console.WriteLine($"Current max value in the queue is: {numbers.Max()}.");
        }

        public static void AddElementToStack(Stack<char> chars, int NumberOfChars)
        {
            for (int i = 0; i < NumberOfChars; i++)
            {
                try
                {
                    chars.Push(char.Parse(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Value cannot be added to a char Stack");
                }
            }
        }

        public static void GetStackElements(Stack<char> chars)
        {
            foreach (char element in chars)
            {
                Console.WriteLine(element);
            }
        }
    }
}
