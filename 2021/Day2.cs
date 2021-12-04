using System.Text.RegularExpressions;

namespace AdventOfCode._2021
{
    class Day2
    {
        static void Main()
        {
            Part1();
            Part2();
        }

        private static List<string> ReadInput()
        {
            return File.ReadAllLines(@"./2021/Day2_Input.txt").ToList();
        }

        private static void Part1()
        {
            List<string> input = ReadInput();
            int horizontal = 0;
            int depth = 0;

            for (int i = 0; i < input.Count; i++)
            {
                switch (Regex.Match(input[i], @"[^\s\d]+").Value.ToLower())
                {
                    case "forward":
                        horizontal += ExtractIntFromString(input[i]);
                        break;
                    case "up":
                        depth -= ExtractIntFromString(input[i]);
                        break;
                    case "down":
                        depth += ExtractIntFromString(input[i]);
                        break;
                }
            }

            Console.WriteLine($"Part 1: horizontal = {horizontal} depth = {depth}");
            Console.WriteLine($"Part 1: {horizontal * depth}");
        }

        private static void Part2()
        {
            List<string> input = ReadInput();
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < input.Count; i++)
            {
                switch (Regex.Match(input[i], @"[^\s\d]+").Value.ToLower())
                {
                    case "forward":
                        horizontal += ExtractIntFromString(input[i]);
                        depth += aim * ExtractIntFromString(input[i]);
                        break;
                    case "up":  
                        aim -= ExtractIntFromString(input[i]);
                        break;
                    case "down":
                        aim += ExtractIntFromString(input[i]);
                        break;
                }
            }

            Console.WriteLine($"Part 2: horizontal = {horizontal} depth = {depth}");
            Console.WriteLine($"Part 2: {horizontal * depth}");
        }

        private static int ExtractIntFromString(string input)
        {
            return Int32.Parse(Regex.Match(input, @"[^[A-Za-z\s]+").Value);
        }
    }
}
