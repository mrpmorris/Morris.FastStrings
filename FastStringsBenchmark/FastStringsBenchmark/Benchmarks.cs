using BenchmarkDotNet.Attributes;
using Morris.FastStrings;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace FastStringsBenchmark;

[MemoryDiagnoser]
public class Benchmarks
{
	private const StringComparison Comparison = StringComparison.CurrentCultureIgnoreCase;
	public static readonly ImmutableArray<string> LeastCommonSearchWords;
	public static readonly ImmutableArray<string> MostCommonSearchWords;
	public static readonly string WarAndPeace = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxHello";

	static Benchmarks()
	{
		WarAndPeace = File.ReadAllText("WarAndPeace.txt");
		var regex = new Regex(@"\b\w+\b");
		var groupedWords = regex
			.Matches(WarAndPeace)
			.Select(x => x.Value)
			.Where(x => x != "FirstWord")
			.Where(x => x != "LastWord")
			.Where(x => x != "稀有词")
			.Where(x => x != "ਇੱਕਦੁਰਲੱਭਵਾਕਾਂਸ਼ਜੋਟੈਕਸਟਦੇਅੰਤਦੇਨੇੜੇਇੱਕਵਾਰਦਿਖਾਈਦਿੰਦਾਹੈ")
			.GroupBy(x => x);

		LeastCommonSearchWords = groupedWords
			.OrderBy(x => x.Count())
			.Take(10)
			.Select(x => x.Key)
			.ToImmutableArray();

		MostCommonSearchWords = groupedWords
			.OrderByDescending(x => x.Count())
			.Take(10)
			.Select(x => x.Key)
			.ToImmutableArray();
	}

	[Benchmark]
	public void IndexOfRareWordNearEndOfText()
	{
		WarAndPeace.IndexOf("稀有词", Comparison);
	}

	[Benchmark]
	public void FastIndexOfRareWordNearEndOfText()
	{
		WarAndPeace.FastIndexOf("稀有词", Comparison);
	}

	[Benchmark]
	public void IndexOfRareSentenceNearEndOfText()
	{
		WarAndPeace.IndexOf("ਇੱਕਦੁਰਲੱਭਵਾਕਾਂਸ਼ਜੋਟੈਕਸਟਦੇਅੰਤਦੇਨੇੜੇਇੱਕਵਾਰਦਿਖਾਈਦਿੰਦਾਹੈ", Comparison);
	}

	[Benchmark]
	public void FastIndexOfRareSentenceNearEndOfText()
	{
		WarAndPeace.FastIndexOf("ਇੱਕਦੁਰਲੱਭਵਾਕਾਂਸ਼ਜੋਟੈਕਸਟਦੇਅੰਤਦੇਨੇੜੇਇੱਕਵਾਰਦਿਖਾਈਦਿੰਦਾਹੈ", Comparison);
	}

	[Benchmark]
	public void IndexOfFirstWord()
	{
		WarAndPeace.IndexOf("FirstWord", Comparison);
	}

	[Benchmark]
	public void FastIndexOfFirstWord()
	{
		WarAndPeace.FastIndexOf("FirstWord", Comparison);
	}

	[Benchmark]
	public void IndexOfLastWord()
	{
		WarAndPeace.IndexOf("LastWord", Comparison);
	}

	[Benchmark]
	public void FastIndexOfLastWord()
	{
		WarAndPeace.FastIndexOf("LastWord", Comparison);
	}

	[Benchmark]
	public void IndexOf10LeastCommonWords()
	{
		foreach (string searchWord in LeastCommonSearchWords)
			WarAndPeace.IndexOf(searchWord, Comparison);
	}

	[Benchmark]
	public void FastIndexOf10LeastCommonWords()
	{
		foreach (string searchWord in LeastCommonSearchWords)
			WarAndPeace.FastIndexOf(searchWord, Comparison);
	}

	[Benchmark]
	public void IndexOf10MostCommonWords()
	{
		foreach (string searchWord in MostCommonSearchWords)
			WarAndPeace.IndexOf(searchWord, Comparison);
	}

	[Benchmark]
	public void FastIndexOf10MostCommonWords()
	{
		foreach (string searchWord in MostCommonSearchWords)
			WarAndPeace.FastIndexOf(searchWord, Comparison);
	}
}
