namespace AdventOfCode
{
    public static class Day9
    {
        public static int Part1()
        {
            int[,] input = DataService.GetDay9Data();
            List<int> result = new List<int>();

            for (int y = 0; y < input.GetLength(0); y++)
            {
                for (int x = 0; x < input.GetLength(1); x++)
                {
                    if (GetAdjacentLocations(input, y, x).All(loc => input[y, x] < loc.value))
                        result.Add(input[y, x]);
                }
            }

            return result.Sum(x => x + 1);
        }

        public static int Part2()
        {
            int[,] input = DataService.GetDay9Data();
            List<int> result = new List<int>();

            for (int y = 0; y < input.GetLength(0); y++)
            {
                for (int x = 0; x < input.GetLength(1); x++)
                {
                    if (input.GetAdjacentLocations(y, x).All(loc => input[y, x] < loc.value))
                        result.Add(input.CountBasinSize((y, x)));
                }
            }

            IEnumerable<int> relevantResults = result.OrderByDescending(x => x).Take(3);
            return relevantResults.Aggregate((x, y) => x * y);
        }

        private static List<(int y, int x, int value)> GetAdjacentLocations(this int[,] input, int y, int x)
        {
            List<(int y, int x, int value)> adjacentLocations = new List<(int y, int x, int value)>();

            if (y > 0)
                adjacentLocations.Add((y - 1, x, input[y - 1, x]));
            if (x < input.GetLength(1) - 1)
                adjacentLocations.Add((y, x + 1, input[y, x + 1]));
            if (y < input.GetLength(0) - 1)
                adjacentLocations.Add((y + 1, x, input[y + 1, x]));
            if (x > 0)
                adjacentLocations.Add((y, x - 1, input[y, x - 1]));

            return adjacentLocations;
        }

        private static int CountBasinSize(this int[,] input, (int y, int x) startPoint)
        {
            int result = 1;
            List<(int y, int x)> visited = new List<(int y, int x)>();
            Queue<(int y, int x)> nextPoint = new Queue<(int y, int x)>();

            visited.Add(startPoint);
            nextPoint.Enqueue(startPoint);

            while (nextPoint.Count > 0)
            {
                (int cy, int cx) = nextPoint.Dequeue();
                foreach ((int y, int x, int value) in input.GetAdjacentLocations(cy, cx))
                {
                    if (visited.Contains((y, x))) continue;

                    if (value < 9)
                    {
                        result++;
                        nextPoint.Enqueue((y, x));
                    }

                    visited.Add((y, x));
                }
            }

            return result;
        }
    }
}