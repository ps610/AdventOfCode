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
                    }
                }
            }

            return flashCount;
        }

        public static int Part2()
        {
            //int[,] input = DataService.GetDay11Data();

            return 0;
        }

        private static int FlashAdjacent(this int[,] input, int y, int x, List<string> alreadyFlashed)
        {
            int flashCount = 0;

            if (y > 0)
            {
                if (!alreadyFlashed.Contains($"{y - 1}.{x}"))
                {
                    input[y - 1, x]++;
                    if (input[y - 1, x] > 9)
                    {
                        flashCount++;
                        input[y - 1, x] = 0;
                        alreadyFlashed.Add($"{y - 1}.{x}");
                        flashCount += input.FlashAdjacent(y - 1, x, alreadyFlashed);
                    }
                }
            }

            if (y > 0 && x < input.GetLength(1) - 1)
            {
                if (!alreadyFlashed.Contains($"{y - 1}.{x + 1}"))
                {
                    input[y - 1, x + 1]++;
                    if (input[y - 1, x + 1] > 9)
                    {
                        flashCount++;
                        input[y - 1, x + 1] = 0;
                        alreadyFlashed.Add($"{y - 1}.{x + 1}");
                        flashCount += input.FlashAdjacent(y - 1, x + 1, alreadyFlashed);
                    }
                }
            }

            if (x < input.GetLength(1) - 1)
            {
                if (!alreadyFlashed.Contains($"{y}.{x + 1}"))
                {
                    input[y, x + 1]++;
                    if (input[y, x + 1] > 9)
                    {
                        flashCount++;
                        input[y, x + 1] = 0;
                        alreadyFlashed.Add($"{y}.{x + 1}");
                        flashCount += input.FlashAdjacent(y, x + 1, alreadyFlashed);
                    }
                }
            }

            if (x < input.GetLength(1) - 1 && y < input.GetLength(0) - 1)
            {
                if (!alreadyFlashed.Contains($"{y + 1}.{x + 1}"))
                {
                    input[y + 1, x + 1]++;
                    if (input[y + 1, x + 1] > 9)
                    {
                        flashCount++;
                        input[y + 1, x + 1] = 0;
                        alreadyFlashed.Add($"{y + 1}.{x + 1}");
                        flashCount += input.FlashAdjacent(y + 1, x + 1, alreadyFlashed);
                    }
                }
            }


            if (y < input.GetLength(0) - 1)
            {
                if (!alreadyFlashed.Contains($"{y + 1}.{x}"))
                {
                    input[y + 1, x]++;
                    if (input[y + 1, x] > 9)
                    {
                        flashCount++;
                        input[y + 1, x] = 0;
                        alreadyFlashed.Add($"{y + 1}.{x}");
                        flashCount += input.FlashAdjacent(y + 1, x, alreadyFlashed);
                    }
                }
            }

            if (y < input.GetLength(0) - 1 && x > 0)
            {
                if (!alreadyFlashed.Contains($"{y + 1}.{x - 1}"))
                {
                    input[y + 1, x - 1]++;
                    if (input[y + 1, x - 1] > 9)
                    {
                        flashCount++;
                        input[y + 1, x - 1] = 0;
                        alreadyFlashed.Add($"{y + 1}.{x - 1}");
                        flashCount += input.FlashAdjacent(y + 1, x - 1, alreadyFlashed);
                    }
                }
            }

            if (x > 0)
            {
                if (!alreadyFlashed.Contains($"{y}.{x - 1}"))
                {
                    input[y, x - 1]++;
                    if (input[y, x - 1] > 9)
                    {
                        flashCount++;
                        input[y, x - 1] = 0;
                        alreadyFlashed.Add($"{y}.{x - 1}");
                        flashCount += input.FlashAdjacent(y, x - 1, alreadyFlashed);
                    }
                }
            }

            if (x > 0 && y > 0)
            {
                if (!alreadyFlashed.Contains($"{y - 1}.{x - 1}"))
                {
                    input[y - 1, x - 1]++;
                    if (input[y - 1, x - 1] > 9)
                    {
                        flashCount++;
                        input[y - 1, x - 1] = 0;
                        alreadyFlashed.Add($"{y - 1}.{x - 1}");
                        flashCount += input.FlashAdjacent(y - 1, x - 1, alreadyFlashed);
                    }
                }
            }

            return flashCount;
        }
    }
}