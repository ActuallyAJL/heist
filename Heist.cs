﻿using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            string entry = "template";
            Console.WriteLine("Choose a Difficulty Level. 100 is medium difficulty");
            int bankDifficulty = int.Parse(Console.ReadLine());
            Team crew = new Team();
            Heist job;
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
                if (thisMember.SkillLevel > 9000) { Console.WriteLine("It's over 9000!!!!!!!!!!"); }
                Console.WriteLine($"What is {thisMember.Name}'s Courage Factor (decimal between 0.0 and 2.0)?");
                thisMember.CourageFactor = Double.Parse(Console.ReadLine());
                crew.Roster.Add(thisMember);
            }
            Console.WriteLine($"Your {crew.Roster.Count}-Person Crew:");
            Console.WriteLine(crew);
            crew.SkillLevel = 0;
            foreach (TeamMember member in crew.Roster)
            {
                crew.SkillLevel += member.SkillLevel;
            }

            Console.WriteLine("How many times would you like to run this simulation?");
            int trialCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= trialCount; i++)
            {
                job = new Heist();
                bankDifficulty = 100 + job.Luck;
                Console.WriteLine($"Trial number {i} of {trialCount}");
                Console.WriteLine($"Bank Difficulty: {bankDifficulty}");
                Console.WriteLine($"Team Combined Skill: {crew.SkillLevel}");

                if (crew.SkillLevel >= bankDifficulty)
                {
                    Console.WriteLine("HEIST SUCCESS!");
                }
                else
                {
                    Console.WriteLine("WASTED!");
                }
            }
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

            public int SkillLevel { get; set; }

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

        public class Heist
        {
            public int Luck { get; set; }

            public Heist()
            {
                Luck = new Random().Next(-10, 11);
            }
        }
    }
}
