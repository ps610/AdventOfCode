namespace AdventOfCode;

public static class StringExtension
{
    public static bool ContainsAllCharsOf(this string source, string input) => input.All(source.Contains);
    public static bool ContainsAllCharsOf(this string source, IEnumerable<char> input) => input.All(source.Contains);
}