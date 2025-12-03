using AdventOfCode;

WriteResultToConsole(1, Day1.Part1(), Day1.Part2());
return;

void WriteResultToConsole<T, K>(int day, T part1, K part2)
{
    Console.WriteLine($"Day {day}");
    Console.WriteLine($"  Part 1: {part1}");
    Console.WriteLine($"  Part 2: {part2}");
    Console.WriteLine("------------------------");
}