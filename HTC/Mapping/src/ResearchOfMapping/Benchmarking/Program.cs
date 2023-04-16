using BenchmarkDotNet.Running;
using Benchmarking.BenchmarkEnvironments;

namespace Benchmarking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkWithInMemoryData>();

            Console.WriteLine("Benchmarking finished. Press any key for close application");
            Console.ReadKey();
        }
    }
}