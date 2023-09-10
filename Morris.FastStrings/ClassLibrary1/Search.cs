namespace Morris.FastStrings;

public static class Search
{
	public static int FastIndexOf(this string source, string value, StringComparison comparison)
	{
		StringComparer comparer = StringComparer.FromComparison(comparison);
		var jumpTable = new Dictionary<string, int>(comparer);
		ReadOnlySpan<char> valueChars = value.AsSpan();
		int valueLength = value.Length;
		int valueLengthMinusOne = valueLength - 1;
		for (int o = 0; o < valueLengthMinusOne; o++)
			jumpTable[valueChars[o].ToString()] = valueLengthMinusOne - o;

		var sourceChars = source.AsSpan();
		int sourceLengthMinusOne = sourceChars.Length - 1;
		int lastPossibleIndex = sourceLengthMinusOne - valueLengthMinusOne;
		int x = 0;
		while (x <= lastPossibleIndex)
		{
			int sourceIndex = x + valueLengthMinusOne;
			for (int y = valueLengthMinusOne; y >= 0; y--)
			{
				if (comparer.Equals(sourceChars[sourceIndex], valueChars[y]))
				{
					if (y == 0)
						return x;
					sourceIndex--;
					continue;
				}
				else
				{
					if (jumpTable.TryGetValue(sourceChars[sourceIndex].ToString(), out int jumpSize))
						x += jumpSize;
					else
						x += valueLength;
					break;
				}
			}
		}
		return -1;
	}
}
