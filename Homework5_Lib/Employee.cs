namespace Homework5_Lib
{
    public class Employee
    {
        public const int _defaultSalary = 500;
        public string? _firstName;
        public string? _lastName;
        public int _age;
        public string? _jobTitle;
        public string? _seniority;
        public double _experience;
        public double _salary;
        public Employee(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }
        public Employee(string firstName, string lastName, int age, double experience, string jobTitle) : this (firstName, lastName, age)
        {
            _experience = experience;
            _jobTitle = jobTitle;
        }
        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }
        public double CalculateSalary()
        {
            if (_experience >= 0 & _experience <= 1)
            {
                _salary = _defaultSalary;
            }
            else if (_experience > 1 & _experience <= 5)
            {
                _salary = _defaultSalary * _experience;
            }
            else if (_experience > 5)
            {
                _salary = _defaultSalary * _experience;
            }
            else
            {
                Console.WriteLine("Please verify set experience");
            }
            return _salary;
        }
        public string CalculateSeniority()
        {
            if (_experience >= 0 & _experience <= 1)
            {
                _seniority = "Junior";
            }
            else if (_experience > 1 & _experience <= 5)
            {
                _seniority = "Middle";
            }
            else if (_experience > 5)
            {
                _seniority = "Senior";
            }
            return _seniority;

        }
        public void DisplaySalary() => Console.WriteLine($"Salary:{CalculateSalary()}$");
        public void DisplayPersonalData() => Console.WriteLine($"Name: {_firstName} {_lastName}, age:{_age} years.");
        public void DisplayJobData() => Console.WriteLine($"{CalculateSeniority()} {_jobTitle}");
    }
}