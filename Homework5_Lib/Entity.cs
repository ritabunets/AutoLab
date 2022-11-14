namespace Homework5_Lib
{
    public class Entity
    {
        public string entityType;
        public int id;
        public string manager;
        public Employee[] members = new Employee[0];

        public Entity(string entityType, int id, string manager)
        {
            this.entityType = entityType;
            this.id = id;
            this.manager = manager;
        }

        public void GetEntityData() => Console.WriteLine($"{entityType} | {id} | Manager: {manager}\n");

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
