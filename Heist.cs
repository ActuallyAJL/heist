using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            string entry = "template";
            Team crew = new Team();
            crew.Roster = new List<TeamMember>();
            while (entry != "")
            {
                TeamMember thisMember = new TeamMember();
                Console.WriteLine("Enter the next team members name, or press enter if your crew is complete");
                entry = Console.ReadLine();
                if (entry == "")
                {
                    break;
                }
                thisMember.Name = entry;
                Console.WriteLine($"What is {thisMember.Name}'s Skill Level (positive integer)?");
                thisMember.SkillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine($"What is {thisMember.Name}'s Courage Factor (decimal between 0.0 and 2.0)?");
                thisMember.CourageFactor = Double.Parse(Console.ReadLine());
                Console.WriteLine("Your Team Member:");
                Console.WriteLine(thisMember);
                crew.Roster.Add(thisMember);
            }
            Console.WriteLine($"Your {crew.Roster.Count}-Person Crew:");
            Console.WriteLine(crew);
        }

        public class TeamMember
        {
            public string Name { get; set; }
            public int SkillLevel { get; set; }
            public double CourageFactor { get; set; }

            public TeamMember()
            {
                Name = "template";
                SkillLevel = 0;
                CourageFactor = 0.0;
            }

            public TeamMember(string n)
            {
                Name = n;
            }

            public TeamMember(int sk)
            {
                SkillLevel = sk;
            }

            public TeamMember(double cf)
            {
                CourageFactor = cf;
            }

            public TeamMember(string n, int sk, double cf)
            {
                Name = n;
                SkillLevel = sk;
                CourageFactor = cf;
            }

            public override string ToString()
            {
                return $"{Name}: Skill Level-{SkillLevel}, Courage Factor-{CourageFactor}";
            }
        }

        public class Team
        {
            public List<TeamMember> Roster { get; set; }

            public override string ToString()
            {
                string myTeamString = "";
                foreach (TeamMember tm in Roster)
                {
                    myTeamString += $"{tm.Name}: Skill Level-{tm.SkillLevel}, Courage Factor-{tm.CourageFactor}\n";
                }
                return myTeamString;
            }
        }
    }
}
