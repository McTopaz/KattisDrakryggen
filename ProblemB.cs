using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisDrakryggen
{
    public class ProblemB
    {
        int amount = 0;

        public void Run(string line)
        {
            var data = ParseLine(line);

            while(data.S > 0 || data.L > 0)
            {
                RunLongBatchesOnAllMachines(data);

                if (data.L >= data.M) continue;

                var remaining = RunRemainingLongBatchesAndReturnIdleMachines(data);

                if (remaining.running)
                {
                    RunAnyShortBatchesWhileWatingOnRemaingLongBatches(data, remaining.idle);
                }

                RunShortBatchesOnAllMachines(data);

                if (data.S >= data.M || data.S <= 0) continue;

                RunRemainingShortBatches(data);
            }

            Console.WriteLine(amount);
        }

        private Data ParseLine(string line)
        {
            var parts = line.Split(' ');
            var data = new Data
            {
                Q = int.Parse(parts[0]),    // Time needed to complete longer batches
                M = int.Parse(parts[1]),    // Ownmed machines
                S = int.Parse(parts[2]),    // Number of 1 sec slots purchased
                L = int.Parse(parts[3]),    // Number of Q sec time slots purchased
            };
            
            return data;
        }

        private void RunLongBatchesOnAllMachines(Data data)
        {
            if (data.L >= data.M)
            {
                amount += data.Q;
                data.L -= data.M;
            }
        }

        private (bool running, int idle) RunRemainingLongBatchesAndReturnIdleMachines(Data data)
        {
            if (data.L == 0) return (false, data.M);

            amount += data.Q;
            var idle = data.M - data.L;
            data.L = 0;
            return (true, idle);
        }

        private void RunAnyShortBatchesWhileWatingOnRemaingLongBatches(Data data, int idle)
        {
            var shortBatchesPossibleToRun = data.Q * idle;
            data.S -= shortBatchesPossibleToRun;
        }

        private void RunShortBatchesOnAllMachines(Data data)
        {
            if (data.L == 0 && data.S >= data.M)
            {
                amount++;
                data.S -= data.M;
            }
        }

        private void RunRemainingShortBatches(Data data)
        {
            amount++;
            data.S = 0;
        }
    }

    public record Data
    {
        public int Q { get; set; }
        public int M { get; set; }
        public int S { get; set; }
        public int L { get; set; }

        public override string ToString()
        {
            return $"{Q} {M} {S} {L}";
        }
    }
}
