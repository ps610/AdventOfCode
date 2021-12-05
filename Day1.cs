namespace AdventOfCode
{
    public class Day1
    {
        public static int Part1()
        {
            List<int> data = DataService.GetDay1Data();
            return CalculateDepthIncreases(data);
        }

        public static int Part2()
        {
            List<int> data = DataService.GetDay1Data();
            List<int> smoothedData = new();

            for (int i = 0; i < data.Count - 2; i++)
            {
                int r = data.GetRange(i, 3).Sum();
                smoothedData.Add(r);
            }

            return CalculateDepthIncreases(smoothedData);
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