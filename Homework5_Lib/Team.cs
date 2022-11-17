namespace Homework5_Lib
{
    public class Team : Entity
    {
        private string? _domain;

        public Team(string entityType, int id, string domain, string manager, Employee[] members) : base(entityType, id, manager)
        {
            _domain = domain;
            Members = members;
        }

        public override void GetEntityData() => Console.WriteLine($"{EntityType} | {Id} | {_domain} | Manager: {Manager}");
    }
}