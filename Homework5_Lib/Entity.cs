namespace Homework5_Lib
{
    public abstract class Entity
    {
        protected string entityType;
        protected int id;
        protected string manager;
        protected Employee[] members = new Employee[0];

        public Entity(string entityType, int id, string manager)
        {
            this.entityType = entityType;
            this.id = id;
            this.manager = manager;
        }

        public virtual void GetEntityData() => Console.WriteLine($"{entityType} | {id} | Manager: {manager}\n");

        public void GetEntityMembersData()
        {
            Console.WriteLine($"Members of {entityType}{id}:");
            try
            {
                foreach (var employee in members)
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
