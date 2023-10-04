using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisDrakryggen
{
    public class ProblemC
    {
        public void Run(List<string> lines)
        {
            if (lines == null || lines.Count == 0 || string.IsNullOrWhiteSpace(lines.First()))
            {
                Console.WriteLine(0);
                return;
            }

            var testCases = int.Parse(lines[0]);
            var index = 1;

            if (testCases == 0)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = 0; i < testCases; i++)
            {
                // Patse data from input.
                var cavesAndTunnels = ParseCavesAndTunnels(lines[index]);
                index++;
                var tunnels = ParseTunnels(lines.Skip(index).Take(cavesAndTunnels.tunnels));
                index += cavesAndTunnels.tunnels;
                var idols = int.Parse(lines[index]);
                index++;
                var cavesWithIdols = ParseCavesWithIdols(lines[index]);
                index++;
                var air = int.Parse(lines[index]);
                index++;

                if (cavesAndTunnels.tunnels > cavesAndTunnels.caves)
                {
                    Console.WriteLine(0);
                    continue;
                }

                if (idols == 0)
                {
                    Console.WriteLine(0);
                    continue;
                }

                // Validate tunnels are connected to START, existing caves and air usage.
                var validTunnels = tunnels.Where(t => t.start == 0)
                    .Where(t => cavesWithIdols.Contains(t.end))
                    .Where(t => (t.air * 2) <= air)
                    .OrderByDescending(t => t.air)
                    .ToList();

                // Validate how many tunnels can be dived in based on amount of air.
                while (validTunnels.Count() > 0)
                {
                    var totalAirNeededInTunnels = validTunnels.Sum(t => t.air) * 2;
                    if (totalAirNeededInTunnels > air)
                    {
                        validTunnels = validTunnels.Skip(1).ToList();
                        continue;
                    }
                    break;
                }

                Console.WriteLine(validTunnels.Count());
            }
        }

        private (int caves, int tunnels) ParseCavesAndTunnels(string line)
        {
            var parts = line.Split(' ');
            var caves = int.Parse(parts[0]);
            var tunnels = int.Parse(parts[1]);
            return (caves, tunnels);
        }

        private List<(int start, int end, int air)> ParseTunnels(IEnumerable<string> lines)
        {
            var list = new List<(int, int, int)>();
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var start = int.Parse(parts[0]);
                var end = int.Parse(parts[1]);
                var l = int.Parse(parts[2]);
                list.Add((start, end, l));
            }
            return list;
        }

        private List<int> ParseCavesWithIdols(string line)
        {
            return line.Split(' ')
                .Select(p => int.Parse(p))
                .ToList();
        }
    }
}
