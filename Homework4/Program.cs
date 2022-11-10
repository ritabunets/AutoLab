using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;

namespace Homework
{
    class Homework4
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
        }

        //Task 1 - Calculate the sum of numbers from 0 to entered number.
        private static void Task1()
        {
            Console.WriteLine("Enter any positive number:");
            try
            {
                var userNum = int.Parse(Console.ReadLine());
                if (userNum > 0)
                {
                    int result = 0;
                    for (int i = 0; i < userNum; i++)
                    {
                        result += i;
                    }
                    Console.WriteLine($"The sum is: {result}");
                }
                else
                {
                    Console.WriteLine("Entered number less than zero");
                }
            }
            catch
            {
                Console.WriteLine("Еntered value cannot be convert to short");
            }
        }

        //Task 2 - Display multiplication table for number 3 via while loop.
        private static void Task2()
        {
            int i = 1;
            int num = 3;
            int res = 0;
            while (i < 11)
            {
                res = num * i;
                Console.WriteLine($"{i} * {num} = {res}");
                i++;
            }
        }

        //Task 3 - Display result of multiplying numbers from a given array.
        private static void Task3()
        {
            int[] numbers = { 3, 5, 9, 8, 15 };
            int multOfArrayNumbers = 1;
            foreach (int number in numbers)
            {
                multOfArrayNumbers *= number;
            }
            Console.WriteLine($"The result of multiplying numbers from a given array is: {multOfArrayNumbers}");
        }

        //Task 4 - Display how many times should 2048 be divided by 2 to make it less than 10.
        private static void Task4()
        {
            int initialNum = 2048;
            int i = 0;
            while (initialNum > 10)
            {
                initialNum /= 2;
                i++;
            }
            Console.WriteLine($"2048 should be divided {i} times by 2 to be less than 10.");
        }

        //Task 5 - Display "Labas!" in case "Hello" word exist in the array.
        private static void Task5()
        {
            const string condWord = "Hello";
            string[] words = { "Privet", "Hey", "Hello", "Hola", "Coca-cola" };
            foreach (string word in words)
            {
                if (word == condWord)
                {
                    Console.WriteLine("Labas!");
                    break;
                }
            }
        }

        //Task 6 - Create an array and calculate the sum of the first and last elements
        private static void Task6()
        {
            int[] numbers = new int[5];
            int sum;
            Console.WriteLine("Enter 5 int numbers to create an array");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            sum = numbers[0] + numbers[numbers.Length - 1];
            Console.WriteLine($"The sum of the first and last elements is: {sum}.");

        }

        //Task 7 - Calculate the sum of the indexes of max and min elements
        private static void Task7()
        {
            int[] numbers = new int[5];
            Console.WriteLine("Enter 5 int numbers to create an array");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int max = numbers[0];
            int indexMax = 0;
            int min = numbers[0];
            int indexMin = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max <= numbers[i])
                {
                    max = numbers[i];
                    indexMax = i;

                }
                else if (min >= numbers[i])
                {
                    min = numbers[i];
                    indexMin = i;
                }
            }
            int sum = indexMax + indexMin;
            Console.WriteLine($"The sum of the indexes of max and min elements is: {sum}.");
        }

        //Task 8 - Create an array and sort it in ascending order.
        private static void Task8()
        {
            int[] customNums = new int[5];
            Console.WriteLine("Enter 5 int numbers to create an array:");
            for (int i = 0; i < customNums.Length; i++)
            {
                customNums[i] = int.Parse(Console.ReadLine());
            }
            int temp;
            for (int i = 0; i < customNums.Length - 1; i++)
            {
                for (int j = i + 1; j < customNums.Length; j++)
                {
                    if (customNums[i] > customNums[j])
                    {
                        temp = customNums[i];
                        customNums[i] = customNums[j];
                        customNums[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted array is:");
            for (int i = 0; i < customNums.Length; i++)
            {
                Console.WriteLine(customNums[i]);
            }
        }

        //Task 9 - Display multiplication table for numbers from 1 to 10.
        private static void Task9()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int res = 0;
            for (int i = 1; i < 11; i++)
            {
                foreach (int number in nums)
                {
                    res = i * number;
                    Console.WriteLine($"{i} * {number} = {res}");
                }
            }
        }
    }
}