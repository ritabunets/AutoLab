namespace Homework5_Lib
{
    public class Team : Entity
    {
        private string? _domain;

        public Team(string entityType, int id, string domain, string manager, Employee[] members) : base(entityType, id, manager)
        {
            _domain = domain;
            this.members = members;
        }

        public new void GetEntityData() => Console.WriteLine($"{entityType} | {id} | {_domain} | Manager: {manager}");
    }
}