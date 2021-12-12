namespace AdventOfCode
{
    public static class AdventOfCode
    {
        public static void Main()
        {
            WriteResultToConsole(1, Day1.Part1(), Day1.Part2());
            WriteResultToConsole(2, Day2.Part1(), Day2.Part2());
            WriteResultToConsole(3, Day3.Part1(), Day3.Part2());
            WriteResultToConsole(4, Day4.Part1(), Day4.Part2());
            WriteResultToConsole(5, Day5.Part1(), Day5.Part2());
            WriteResultToConsole(6, Day6.Part1(), Day6.Part2());
            WriteResultToConsole(7, Day7.Part1(), Day7.Part2());
            WriteResultToConsole(8, Day8.Part1(), Day8.Part2());
            WriteResultToConsole(9, Day9.Part1(), Day9.Part2());
            WriteResultToConsole(10, Day10.Part1(), Day10.Part2());
        }

        private static void WriteResultToConsole<T, K>(int day, T part1, K part2)
        {
            Console.WriteLine($"Day {day}");
            Console.WriteLine($"Part 1: {part1}");
            Console.WriteLine($"Part 2: {part2}");
            Console.WriteLine("------------------------");
        }
    }
}