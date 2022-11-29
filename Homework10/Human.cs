namespace Homework10
{
    public abstract class Human
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public Human(string fname, string lname)
        {
            FName = fname;
            LName = lname;
        }
    }

    public class Woman : Human
    {
        public Woman() : this ("FirstName", "LastName")
        {
        }

        public Woman(string fname, string lname) : base(fname, lname)
        {
        }
    }

    public class Man : Human
    {
        public Man() : this ("FirstName", "LastName")
        {
        }

        public Man(string fname, string lname) : base(fname, lname)
        {
        }
    }
}
