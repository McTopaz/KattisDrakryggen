using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisDrakryggen
{
    public class ProblemA
    {
        public void Run(List<string> lines)
        {
            var count = int.Parse(lines[0]);
            var slates = CountWorkingSlates(lines.Skip(1).Take(count));
            var tb = slates.Sum(t => t.tb);
            var lr = slates.Sum(t => t.lr);
            var min = Math.Min(tb, lr);
            var swords = Math.Floor((double)min / 2);
            var tbSlates = tb - (swords * 2);
            var lrSlates = lr - (swords * 2);
            Console.WriteLine($"{swords} {tbSlates} {lrSlates}");
        }

        private List<(int tb, int lr)> CountWorkingSlates(IEnumerable<string> lines)
        {
            var list = new List<(int tb, int lr)>();
            foreach (var line in lines)
            {
                var tb = line.Substring(0, 2).Count(c => c == '0');
                var lr = line.Substring(2, 2).Count(c => c == '0');
                list.Add((tb, lr));
            }
            return list;
        }
    }
}
