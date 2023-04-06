using BenchmarkDotNet.Running;
using Benchmarking.BenchmarkEnvironments;

namespace Benchmarking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();

            Console.WriteLine("Benchmarking finished. Press any key for close application");
            Console.ReadKey();
        }
    }
}