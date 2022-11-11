namespace Homework5_Lib
{
    public class Team
    {
        public int _teamId;
        public string _teamManager;
        public string _teamDomain;
        public Employee[] _teamMembers = new Employee[0];
        public Team(int teamId, string teamDomain, string teamManager)
        {
            _teamId = teamId;
            _teamDomain = teamDomain;
            _teamManager = teamManager;
        }
        public Team(int teamId, string teamDomain, string teamManager, Employee[] teamMembers) : this (teamId, teamDomain, teamManager)
        {
            _teamMembers = teamMembers;
        }
        public void DisplayTeamData() => Console.WriteLine($"T{_teamId} | {_teamDomain} | Manager: {_teamManager}");       
        public void DisplayTeamMembers()
        {
            Console.WriteLine($"Team members of T{_teamId}:");
            try
            {
                foreach (var employee in _teamMembers)
                {
                    employee.DisplayPersonalData();
                    employee.DisplayJobData();
                    employee.DisplaySalary();
                }
            }
            catch
            {
                Console.WriteLine("There is no members in this team.");
            }
            Console.WriteLine($"\n");
        }
    }    
}