using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Homework
{
    class Homework3
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

        //Add 5 to the variable
        private static void Task1()
        {
            int num = 20;
            num += 5;
            Console.WriteLine($"«Variable: {num}»");
        }

        //Calculate how many years, months and days in the entered value                
        private static void Task2()
        {
            int daysInYear = 365;
            int daysInMonth = 30;
            int userNumber = Convert.ToInt32(Console.ReadLine());
            int years = userNumber / daysInYear;
            int months = (userNumber % daysInYear) / daysInMonth;
            int days = (userNumber % daysInYear) % daysInMonth;
            Console.WriteLine($"{years} years, {months} months, {days} days.");
        }

        //Calculate n = n + n * 2 via cheating way
        private static void Task3()
        {
            int userNum = Convert.ToInt32(Console.ReadLine());
            userNum *= 3;
            Console.WriteLine(userNum);
        }

        //Show variables and their type
        private static void Task4()
        {
            sbyte first = -34;
            Console.WriteLine($"{first} has type {first.GetType()}");
            byte second = 4;
            Console.WriteLine($"{second} has type {second.GetType()}");
            string third = "Hello";
            Console.WriteLine($"{third} has type {third.GetType()}");
            char fourth = 'R';
            Console.WriteLine($"{fourth} has type {fourth.GetType()}");
            double fifth = 23.093433222;
            Console.WriteLine($"{fifth} has type {fifth.GetType()}");
            ushort sixth = 40000;
            Console.WriteLine($"{sixth} has type {sixth.GetType()}");
            bool seventh = true;
            Console.WriteLine($"{seventh} has type {seventh.GetType()}");
            byte eighth = 0;
            Console.WriteLine($"{eighth} has type {eighth.GetType()}");
        }

        //Convert entrered values to new type
        private static void Task5()
        {
            try
            {
                short userValue1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine(userValue1);
            }

            catch
            {
                Console.WriteLine("Еntered value cannot be convert to short");
            }

            try
            {
                ulong userValue2 = Convert.ToUInt64(Console.ReadLine());
                Console.WriteLine(userValue2);
            }

            catch
            {
                Console.WriteLine("Еntered value cannot be convert to ulong");
            }

            try
            {
                char userValue3 = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(userValue3);
            }

            catch
            {
                Console.WriteLine("Еntered value cannot be convert to char");
            }

            try
            {
                double userValue4 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(userValue4);
            }

            catch
            {
                Console.WriteLine("Еntered value cannot be convert to double");
            }
        }

        //Calculate -5 * 7 and decrement the result
        private static void Task6()
        {
            int defNum = -5;
            defNum *= 7;
            Console.WriteLine(--defNum);
        }

        //Determine if the entered number is even or odd
        private static void Task7()
        {
            int uNumber = Convert.ToInt32(Console.ReadLine());

            if (uNumber % 2 == 0)
            {
                Console.WriteLine("Entered number is even");
            }
            else
            {
                Console.WriteLine("Entered number is odd");
            }

        }

        //Show "Working" message in case of successfully passing the conditions
        private static void Task8()
        {
            int a = Convert.ToInt32(Console.ReadLine());

            if (a < 50 & a != 37 & a > 32 | a == 0 || a == 15)
            {
                Console.WriteLine("Working");
            }
            else
            {
                Console.WriteLine("Not working, sorry");
            }

        }

        //Perform an arithmetic operation on the entered numbers depending on the selected operation
        private static void Task9()
        {
            Console.WriteLine("Enter the first number:");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any arithmetic operation from the following: + - / *");
            char operation = Convert.ToChar(Console.ReadLine());
            int result;

            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    Console.WriteLine($"The result is: {result}");
                    break;

                case '-':
                    result = firstNumber - secondNumber;
                    Console.WriteLine($"The result is: {result}");
                    break;

                case '/':
                    result = firstNumber / secondNumber;
                    Console.WriteLine($"The result is: {result}");
                    break;

                case '*':
                    result = firstNumber * secondNumber;
                    Console.WriteLine($"The result is: {result}");
                    break;
            }
        }
    }
}