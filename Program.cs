using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisDrakryggen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TestA();
            //TestB();
            TestC();
        }

        public static void Input(Action<string[]> testMethod)
        {
            string line;
            var lines = new List<string>();
            while ((line = Console.ReadLine()) != null)
            {
                lines.Add(line);
            }

            testMethod(lines.ToArray());
        }

        public static void TestA()
        {
            var lines = new List<string>
            {
                "4",
                "0100",
                "0010",
                "0110",
                "1010",
            };
            new ProblemA().Run(lines);
        }

        public static void TestB()
        {
            new ProblemB().Run("2 4 3 6");      // 4
            new ProblemB().Run("3 4 3 5");      // 6
            new ProblemB().Run("10 2 0 1");     // 10
            new ProblemB().Run("0 4 0 0");      // 0
            new ProblemB().Run("0 4 1 0");      // 1
            new ProblemB().Run("0 4 4 0");      // 1
            new ProblemB().Run("0 4 0 1");      // 0
            new ProblemB().Run("2 4 0 1");      // 2
            new ProblemB().Run("2 4 0 4");      // 2
            new ProblemB().Run("2 4 0 5");      // 4
            new ProblemB().Run("2 4 0 20");     // 10
            new ProblemB().Run("2 4 10 0");     // 3
            new ProblemB().Run("5 4 11 10");    // 16
            new ProblemB().Run("5 2 11 10");    // 31
            new ProblemB().Run("5 3 11 10");    // 21
        }

        public static void TestC()
        {
            //TestC1();
            //TestC2();
            //TestC3();
            //TestC4();
            //TestC5();
            TestC6();
        }

        public static void TestC1()
        {
            var lines = new List<string>
            {
                "3",
                "5 3",      // 1
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "4",
                "1 2 3 4",
                "30",
                "5 3",      // 2
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "4",
                "1 2 3 4",
                "60",
                "5 3",      // 3
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "4",
                "1 2 3 4",
                "10000",
            };
            new ProblemC().Run(lines);
        }

        public static void TestC2()
        {
            var lines = new List<string>
            {
                "4",
                "5 3",      // 1    Only enough air for cave #1
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "4",
                "1 2 3 4",
                "50",
                "5 4",      // 3    Only enough air for caves #1, #2 & #3
                "0 1 10",
                "0 2 20",
                "0 3 15",
                "0 4 100",
                "4",
                "1 2 3 4",
                "90",
                "1 1",      // 0    Not enouch ait for trip to and from cave #1
                "0 1 10",
                "1",
                "1",
                "10",
                "4 4",      // 1    Only air for cave #1
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "0 4 40",
                "2",
                "1 2",
                "20",
            };
            new ProblemC().Run(lines);
        }

        public static void TestC3()
        {
            new ProblemC().Run(null);               // 0
            new ProblemC().Run(new List<string>()); // 0

            var lines = new List<string>
            {
                "",         // 0
            };
            new ProblemC().Run(lines);

            lines = new List<string>
            {
                "0",         // 0
            };
            new ProblemC().Run(lines);

            lines = new List<string>
            {
                "1",
                "0 0",      // 0    No caves, no tunnels, no idols
                "0",
                "0",
                "0",
            };
            new ProblemC().Run(lines);
        }

        public static void TestC4()
        {
            var lines = new List<string>
            {
                "7",
                "5 3",      // 1    One tunnel connect to cave #5 which don't exist
                "0 1 10",
                "0 2 20",
                "0 5 30",
                "4",
                "1 2 3 4",
                "50",
                "5 3",      // 0    All tunnels don't connect to any cave
                "0 5 10",
                "0 6 20",
                "0 7 30",
                "4",
                "1 2 3 4",
                "50",
                "5 3",      // 0    All tunnels don't connect to start
                "7 1 10",
                "7 2 20",
                "7 3 30",
                "4",
                "1 2 3 4",
                "50",
                "5 3",      // 3    No air needed in tunnels
                "0 1 0",
                "0 2 0",
                "0 3 0",
                "4",
                "1 2 3 4",
                "50",
                "5 3",      // 0    No idols
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "0",
                "1 2 3 4",
                "30",
                "5 3",      // 0    Idol exist in unreachable cave
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "1",
                "4",
                "30",
                "5 3",      // 0    No air
                "0 1 10",
                "0 2 20",
                "0 3 30",
                "4",
                "1 2 3 4",
                "0",
                "1 1",      // 0
                "0 1 10",
                "4",
                "2",
                "30",
            };
            new ProblemC().Run(lines);
        }

        public static void TestC5()
        {
            var lines = new List<string>
            {
                "5",
                "1 1",      // 1    More idols than tunnels
                "0 1 10",
                "20000",
                "1",
                "30",
                "1 1",      // 0    Idol exist in non-existing tunnel
                "0 1 10",
                "1",
                "2",
                "30",
                "1 1",      // 1    Claims to be more caves with idols than actual caves
                "0 1 10",
                "1",
                "1 2",
                "30",
                "1 1",      // 0    Claims to be non-existing caves with idols then actual caves
                "0 1 10",
                "1",
                "2 3",
                "30",
                "1 2",      // 0    More tunnels than caves
                "0 1 10",
                "0 1 20",
                "1",
                "1 2",
                "300",
            };
            new ProblemC().Run(lines);
        }

        public static void TestC6()
        {
            var lines = new List<string>
            {
                "1",
                "1 2",      // 
                "0 1 10",
                "0 1 20",
                "1",
                "1 2",
                "300",
            };
            new ProblemC().Run(lines);
        }
    }
}