namespace Homework5_Lib
{
    public class Group : Entity
    {
        private Team[] _teams = new Team[0];

        public Group(string entityType, int id, string manager) : base(entityType, id, manager)
        {
        }

        public void AddTeamToGroup(Team[] groupTeams)
        {
            foreach (Team groupTeam in groupTeams)
            {
                var arrayLength = _teams.Length + 1;
                Array.Resize(ref _teams, arrayLength);
                _teams.SetValue(groupTeam, _teams.Length - 1);
            }
        }

        public void GetGroupTeamsData()
        {
            Console.WriteLine($"Teams of {entityType}{id}:");
            try
            {
                foreach (var team in _teams)
                {
                    team.GetEntityData();
                    team.GetEntityMembersData();
                }
            }
            catch
            {
                Console.WriteLine($"There is no teams in this {entityType}.");
            }
            Console.WriteLine("\n");
        }
    }
}