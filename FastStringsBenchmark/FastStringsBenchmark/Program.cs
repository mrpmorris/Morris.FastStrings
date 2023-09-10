using BenchmarkDotNet.Running;
using Morris.FastStrings;

namespace FastStringsBenchmark
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var benchmark = BenchmarkRunner.Run(typeof(Program).Assembly);
			Console.Write(benchmark.ToString());
		}
	}
}
