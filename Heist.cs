using System;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            TeamMember member1 = new TeamMember();
            Console.WriteLine("Enter the first team members name:");
            member1.Name = Console.ReadLine();
            Console.WriteLine($"What is {member1.Name}'s Skill Level (positive integer)?");
            member1.SkillLevel = int.Parse(Console.ReadLine());
            Console.WriteLine($"What is {member1.Name}'s Courage Factor (decimal between 0.0 and 2.0)?");
            member1.CourageFactor = Double.Parse(Console.ReadLine());
            Console.WriteLine(member1);
        }

        public class TeamMember
        {
            public string Name { get; set; }
            public int SkillLevel { get; set; }
            public double CourageFactor { get; set; }

            public override string ToString()
            {
                return $"{Name}: Skill Level-{SkillLevel}, Courage Factor-{CourageFactor}";
            }
        }
    }
}
