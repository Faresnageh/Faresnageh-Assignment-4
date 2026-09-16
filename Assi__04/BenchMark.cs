using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assi__04
{
    [MemoryDiagnoser]
    public class BenchMark
    {
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;




        [Benchmark]
        public string? StringConcatenation()
        {
            string msg = "";
            for (int i = 0; i < Iterations; i++)
            {
                msg += "Fares";
            }
            return msg;
        }





        [Benchmark]
        public string? StringBuilderConcatenation()
        {
            StringBuilder msg = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                msg.Append("Fares");
            }
            return msg.ToString();
        }
    }
}
