namespace Homework5_Lib
{
    public class Employee
    {
        private const int DefaultSalary = 500;
        private string? _firstName;
        private string? _lastName;
        private int _age;
        private string? _jobTitle;
        private string? _seniority;
        private double _experience;
        private double _salary;

        public Employee(string firstName, string lastName, int age, double experience, string jobTitle)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _experience = experience;
            _jobTitle = jobTitle;
        }

        public string GetFullName() => $"{_firstName} {_lastName}";

        public double CalculateSalary()
        {
            if (_experience >= 0 & _experience <= 1)
            {
                _salary = DefaultSalary;
            }
            else if (_experience > 1 & _experience <= 5)
            {
                _salary = DefaultSalary * _experience;
            }
            else if (_experience > 5)
            {
                _salary = DefaultSalary * _experience;
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

        public void GetSalary() => Console.WriteLine($"Salary:{CalculateSalary()}$");

        public void GetPersonalData() => Console.WriteLine($"Name: {_firstName} {_lastName}, age:{_age} years.");

        public void GetJobData() => Console.WriteLine($"{CalculateSeniority()} {_jobTitle}");
    }
}