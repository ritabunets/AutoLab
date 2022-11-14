﻿namespace Homework5_Lib
{
    public class Employee
    {
        public const int defaultSalary = 500;
        public string? firstName;
        public string? lastName;
        public int age;
        public string? jobTitle;
        public string? seniority;
        public double experience;
        public double salary;

        public Employee(string firstName, string lastName, int age, double experience, string jobTitle)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.experience = experience;
            this.jobTitle = jobTitle;
        }

        public string GetFullName() => $"{firstName} {lastName}";

        public double CalculateSalary()
        {
            if (experience >= 0 & experience <= 1)
            {
                salary = defaultSalary;
            }
            else if (experience > 1 & experience <= 5)
            {
                salary = defaultSalary * experience;
            }
            else if (experience > 5)
            {
                salary = defaultSalary * experience;
            }
            else
            {
                Console.WriteLine("Please verify set experience");
            }
            return salary;
        }

        public string CalculateSeniority()
        {
            if (experience >= 0 & experience <= 1)
            {
                seniority = "Junior";
            }
            else if (experience > 1 & experience <= 5)
            {
                seniority = "Middle";
            }
            else if (experience > 5)
            {
                seniority = "Senior";
            }
            return seniority;
        }

        public void GetSalary() => Console.WriteLine($"Salary:{CalculateSalary()}$");

        public void GetPersonalData() => Console.WriteLine($"Name: {firstName} {lastName}, age:{age} years.");

        public void GetJobData() => Console.WriteLine($"{CalculateSeniority()} {jobTitle}");
    }
}