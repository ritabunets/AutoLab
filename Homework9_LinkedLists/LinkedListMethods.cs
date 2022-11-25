namespace Homework9_LinkedLists
{
    public class LinkedListMethods
    {
        public static void AddElementAfter(LinkedList<int> linkedNumbers, int ElementToFind, int ElementToAdd)
        {
            var currentNode = linkedNumbers.First;
            while (currentNode != null)
            {
                if (currentNode.Value == ElementToFind)
                {
                    linkedNumbers.AddAfter(currentNode, ElementToAdd);
                }
                currentNode = currentNode.Next;
            }
        }

        public static void GetLinkedList(LinkedList<int> linkedNumbers)
        {
            var currentNode = linkedNumbers.First;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public static void GetJoinedLists(LinkedList<int> linkedNumbers1, LinkedList<int> linkedNumbers2, List<int> joinedNumbers)
        {
            foreach (int linkedNumber2 in linkedNumbers2)
            {
                foreach (int linkedNumber1 in linkedNumbers1)
                {
                   if (linkedNumber1 == linkedNumber2)
                    {
                        joinedNumbers.Add(linkedNumber1);
                    }
                }
            }
        }

        public static void GetElements(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
