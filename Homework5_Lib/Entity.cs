namespace Homework5_Lib
{
    public abstract class Entity
    {
        protected string EntityType;
        protected int Id;
        protected string Manager;
        protected Employee[] Members = new Employee[0];

        public Entity(string entityType, int id, string manager)
        {
            EntityType = entityType;
            Id = id;
            Manager = manager;
        }

        public virtual void GetEntityData() => Console.WriteLine($"{EntityType} | {Id} | Manager: {Manager}\n");

        public void GetEntityMembersData()
        {
            Console.WriteLine($"Members of {EntityType}{Id}:");
            try
            {
                foreach (var employee in Members)
                {
                    employee.GetPersonalData();
                    employee.GetJobData();
                    employee.GetSalary();
                }
            }
            catch
            {
                Console.WriteLine("There is no members in this entity.");
            }
            Console.WriteLine($"\n");
        }
    }
}
