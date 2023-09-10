﻿using BenchmarkDotNet.Attributes;
using Morris.FastStrings;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace FastStringsBenchmark;

[MemoryDiagnoser]
public class Benchmarks
{
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
		WarAndPeace.IndexOf("稀有词");
	}

	[Benchmark]
	public void FastIndexOfRareWordNearEndOfText()
	{
		WarAndPeace.FastIndexOf("稀有词");
	}

	[Benchmark]
	public void IndexOfRareSentenceNearEndOfText()
	{
		WarAndPeace.IndexOf("ਇੱਕ ਦੁਰਲੱਭ ਵਾਕਾਂਸ਼ ਜੋ ਟੈਕਸਟ ਦੇ ਅੰਤ ਦੇ ਨੇੜੇ ਇੱਕ ਵਾਰ ਦਿਖਾਈ ਦਿੰਦਾ ਹੈ");
	}

	[Benchmark]
	public void FastIndexOfRareSentenceNearEndOfText()
	{
		WarAndPeace.FastIndexOf("ਇੱਕ ਦੁਰਲੱਭ ਵਾਕਾਂਸ਼ ਜੋ ਟੈਕਸਟ ਦੇ ਅੰਤ ਦੇ ਨੇੜੇ ਇੱਕ ਵਾਰ ਦਿਖਾਈ ਦਿੰਦਾ ਹੈ");
	}

	[Benchmark]
	public void IndexOfFirstWord()
	{
		WarAndPeace.IndexOf("FirstWord");
	}

	[Benchmark]
	public void FastIndexOfFirstWord()
	{
		WarAndPeace.FastIndexOf("FirstWord");
	}

	[Benchmark]
	public void IndexOfLastWord()
	{
		WarAndPeace.IndexOf("LastWord");
	}

	[Benchmark]
	public void FastIndexOfLastWord()
	{
		WarAndPeace.FastIndexOf("LastWord");
	}

	[Benchmark]
	public void IndexOf10LeastCommonWords()
	{
		foreach (string searchWord in LeastCommonSearchWords)
			WarAndPeace.IndexOf(searchWord);
	}

	[Benchmark]
	public void FastIndexOf10LeastCommonWords()
	{
		foreach (string searchWord in LeastCommonSearchWords)
			WarAndPeace.FastIndexOf(searchWord);
	}

	[Benchmark]
	public void IndexOf10MostCommonWords()
	{
		foreach (string searchWord in MostCommonSearchWords)
			WarAndPeace.IndexOf(searchWord);
	}

	[Benchmark]
	public void FastIndexOf10MostCommonWords()
	{
		foreach (string searchWord in MostCommonSearchWords)
			WarAndPeace.FastIndexOf(searchWord);
	}
}