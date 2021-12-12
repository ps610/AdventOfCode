namespace AdventOfCode
{
    public static class Day11
    {
        public static int Part1()
        {
            int[,] input = DataService.GetDay11Data();
            int flashCount = 0;

            for (int i = 1; i <= 100; i++)
            {
                List<string> alreadyFlashed = new List<string>();

                for (int y = 0; y < input.GetLength(0); y++)
                {
                    for (int x = 0; x < input.GetLength(1); x++)
                    {
                        flashCount += input.FlashLocation(y, x, alreadyFlashed);
                    }
                }
            }

            return flashCount;
        }

        public static int Part2()
        {
            int[,] input = DataService.GetDay11Data();

            for (int i = 1; true; i++)
            {
                List<string> alreadyFlashed = new List<string>();

                for (int y = 0; y < input.GetLength(0); y++)
                {
                    for (int x = 0; x < input.GetLength(1); x++)
                    {
                        input.FlashLocation(y, x, alreadyFlashed);
                    }
                }

                if (alreadyFlashed.Count == input.GetLength(0) * input.GetLength(1))
                    return i;
            }
        }

        private static int FlashLocation(this int[,] input, int y, int x, List<string> alreadyFlashed)
        {
            int flashCount = 0;

            if (!alreadyFlashed.Contains($"{y}.{x}"))
            {
                input[y, x]++;
                if (input[y, x] > 9)
                {
                    flashCount++;
                    input[y, x] = 0;
                    alreadyFlashed.Add($"{y}.{x}");
                    flashCount += input.FlashAdjacent(y, x, alreadyFlashed);
                }
            }

            return flashCount;
        }

        private static int FlashAdjacent(this int[,] input, int y, int x, List<string> alreadyFlashed)
        {
            int flashCount = 0;

            // above
            if (y > 0)
                flashCount += input.FlashLocation(y - 1, x, alreadyFlashed);

            // diagonal right above
            if (y > 0 && x < input.GetLength(1) - 1)
                flashCount += input.FlashLocation(y - 1, x + 1, alreadyFlashed);

            // right
            if (x < input.GetLength(1) - 1)
                flashCount += input.FlashLocation(y, x + 1, alreadyFlashed);

            // diagonal right below
            if (x < input.GetLength(1) - 1 && y < input.GetLength(0) - 1)
                flashCount += input.FlashLocation(y + 1, x + 1, alreadyFlashed);

            // below
            if (y < input.GetLength(0) - 1)
                flashCount += input.FlashLocation(y + 1, x, alreadyFlashed);

            // diagonal left below
            if (y < input.GetLength(0) - 1 && x > 0)
                flashCount += input.FlashLocation(y + 1, x - 1, alreadyFlashed);

            // left
            if (x > 0)
                flashCount += input.FlashLocation(y, x - 1, alreadyFlashed);

            // diagonal left above
            if (x > 0 && y > 0)
                flashCount += input.FlashLocation(y - 1, x - 1, alreadyFlashed);

            return flashCount;
        }
    }
}