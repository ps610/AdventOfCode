namespace AdventOfCode
{
    public class AdventOfCode
    {
        public static void Main()
        {
            #region Day 1
            int day1Part1 = Day1.Part1();
            int day1Part2 = Day1.Part2();
            Console.WriteLine("Day 1");
            Console.WriteLine($"Part 1: {day1Part1}");
            Console.WriteLine($"Part 2: {day1Part2}");
            Console.WriteLine();
            #endregion

            #region Day 2
            (int horizontal, int depth) day2Part1 = Day2.Part1();
            (int horizontal, int depth, int aim) dayPart2 = Day2.Part2();
            Console.WriteLine("Day 2");
            Console.WriteLine($"Part 1: {day2Part1.horizontal * day2Part1.depth}");
            Console.WriteLine($"Part 2: {dayPart2.horizontal * dayPart2.depth}");
            Console.WriteLine();
            #endregion

            #region Day 3
            int day3Part1 = Day3.Part1();
            int day3Part2 = Day3.Part2();
            Console.WriteLine("Day 3");
            Console.WriteLine($"Part 1: {day3Part1}");
            Console.WriteLine($"Part 2: {day3Part2}");
            Console.WriteLine();
            #endregion
        }
    }
}