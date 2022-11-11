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

            Team t1 = new Team(teamId: 1, teamDomain: "FE", teamManager: masha.GetFullName(), teamMembers: new Employee[] { masha });
            Team t2 = new Team(teamId: 2, teamDomain: "QA", teamManager: rita.GetFullName(), teamMembers: new Employee[] { rita, aksana });
            Team t3 = new Team(teamId: 3, teamDomain: "AQA", teamManager: ivan.GetFullName(), teamMembers: new Employee[] { ivan, yauheny });
            Team t4 = new Team(teamId: 4, teamDomain: "BE", teamManager: alex.GetFullName(), teamMembers: new Employee[] { alex });

            Group g2 = new() { _groupId = 4, _groupManager = andrey.GetFullName()};
            var g2Teams = new Team[] { t1, t2, t3, t4 };
            g2.AddTeamToGroup(g2Teams);
            g2.DisplayGroupData();
            g2.DisplayGroupTeams();
        }
    }
}