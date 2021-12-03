namespace AdventOfCode._2021
{
    class Day1
    {
        static void Main()
        {
            Part1();
            Part2();
        }

        private static List<int> ReadInput()
        {
            return File.ReadAllLines(@"./2021/Day1_Input.txt").Select(int.Parse).ToList();
        }

        private static void Part1()
        {
            List<int> input = ReadInput();

            int depthIncreases = CalculateDepthIncreases(input);

            Console.WriteLine("Part 1: " + depthIncreases);
        }

        private static void Part2()
        {
            List<int> input = ReadInput();
            List<int> slidingInput = new List<int>();

            for (int i = 0; i < input.Count -2; i++)
            {
                int r = input.GetRange(i, 3).Sum();
                slidingInput.Add(r);
            }

            int depthIncreases = CalculateDepthIncreases(slidingInput);

            Console.WriteLine("Part 2: " + depthIncreases);
        }

        private static int CalculateDepthIncreases(List<int> input)
        {
            int depthIncreases = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] > input[i - 1])
                    depthIncreases++;
            }

            return depthIncreases;
        }
    }
}