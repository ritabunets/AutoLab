namespace Homework5_Lib
{
    public class Group
    {
        public int _groupId;
        public string? _groupManager;
        public Team[] _groupTeams = new Team[0];

        public Group()
        {
        }
        public void AddTeamToGroup(Team[] groupTeams)
        {
            foreach (Team groupTeam in groupTeams)
            {
                var arrayLength = _groupTeams.Length + 1;
                Array.Resize(ref _groupTeams, arrayLength);
                _groupTeams.SetValue(groupTeam, _groupTeams.Length - 1);
            }
        }
        public void DisplayGroupData()
        {
            Console.WriteLine($"G{_groupId} | Manager: {_groupManager}\n");
        }
        public void DisplayGroupTeams()
        {
            Console.WriteLine($"Teams of G{_groupId}:");
            try
            {
                foreach (var team in _groupTeams)
                {
                    team.DisplayTeamData();
                    team.DisplayTeamMembers();
                }
            }
            catch
            {
                Console.WriteLine("There is no teams in this group.");
            }
            Console.WriteLine("\n");
        }        
    }
}