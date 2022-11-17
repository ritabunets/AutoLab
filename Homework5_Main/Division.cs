using Homework5_Lib;

namespace Homework5_Main
{
    public class Division
    {
        static void Main(string[] args)
        {
            Employee aksana = new Employee(firstName: "Aksana", lastName: "Monakhava", age: 33, experience: 4, jobTitle: "QA");
            Employee rita = new Employee(firstName: "Rita", lastName: "Bunets", age: 26, experience: 6, jobTitle: "QA");
            Employee ivan = new Employee(firstName: "Ivan", lastName: "Zialinski", age: 25, experience: 5, jobTitle: "AQA");
            Employee yauheny = new Employee(firstName: "Yauheni", lastName: "Stsetsiukevich", age: 30, experience: 6, jobTitle: "AQA");
            Employee masha = new Employee(firstName: "Masha", lastName: "Kabash", age: 30, experience: 8, jobTitle: "FE");
            Employee alex = new Employee(firstName: "Alex", lastName: "Shebuchev", age: 30, experience: 12, jobTitle: "BE");
            Employee andrey = new Employee(firstName: "Andrey", lastName: "Kress", age: 35, experience: 15, jobTitle: "DB");

            Team t1 = new Team("Team", id: 1, domain: "FE", manager: masha.GetFullName(), members: new Employee[] { masha });
            Team t2 = new Team("Team", id: 2, domain: "QA", manager: rita.GetFullName(), members: new Employee[] { rita, aksana });
            Team t3 = new Team("Team", id: 3, domain: "AQA", manager: ivan.GetFullName(), members: new Employee[] { ivan, yauheny });
            Team t4 = new Team("Team", id: 4, domain: "BE", manager: alex.GetFullName(), members: new Employee[] { alex });

            Group g2 = new Group (entityType: "Group", id: 2, manager: andrey.GetFullName());
            var g2Teams = new Team[] { t1, t2, t3, t4 };
            g2.AddTeamToGroup(g2Teams);
            g2.GetEntityData();
            g2.GetGroupTeamsData();
        }
    }
}