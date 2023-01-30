namespace Homework17.Models.JsonModels
{
    public class UserToCreate
    {
        public string Name { get; set; }
        public string Job { get; set; }

        public UserToCreate(string name, string job)
        {
            Name = name;
            Job = job;
        }
    }
}