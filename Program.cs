using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;
            var lines = File.ReadLines(args[1]);
            foreach (var line in lines) Console.WriteLine(Evaluator.Evaluate(line));
        }
    }
}
