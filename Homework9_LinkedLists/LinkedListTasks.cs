namespace Homework9_LinkedLists
{
    class LinkedListTasks : LinkedListMethods
    {
        private const int ElementToFind = 6;
        private const int ElementToAdd = 9;

        public static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        public static void Task1()
        {
            Console.WriteLine("---Task 1:");
            LinkedList<int> linkedNumbers = new LinkedList<int>(new[] { 1, 6, 7, 6, 8, 10, 6, 5 });
            Console.WriteLine("Initial linked list is:");
            GetLinkedList(linkedNumbers);
            AddElementAfter(linkedNumbers, ElementToFind, ElementToAdd);
            Console.WriteLine($"Final linked list after {ElementToAdd} was added next to each {ElementToFind} is:");
            GetLinkedList(linkedNumbers);
        }

        public static void Task2()
        {
            Console.WriteLine("---Task 2:");
            LinkedList<int> linkedNumbers1 = new LinkedList<int>(new[] { 1, 7, 6, 10 });
            Console.WriteLine("The first linked list is:");
            GetLinkedList(linkedNumbers1);
            LinkedList<int> linkedNumbers2 = new LinkedList<int>(new[] { 7, 3, 10});
            Console.WriteLine("The second linked list is:");
            GetLinkedList(linkedNumbers2);
            Console.WriteLine("The final joined list is:");
            List<int> joinedNumbers = new List<int>();
            GetJoinedLists(linkedNumbers1, linkedNumbers2, joinedNumbers);
            GetElements(joinedNumbers);
        }
    }
}