namespace AdventOfCode
{
    public static class Day5
    {
        public static int Part1()
        {
            List<(int x1, int y1, int x2, int y2)> coords = DataService.GetDay5Data();

            int xSize = coords.Max(c => Math.Max(c.x1, c.x2)) + 1;
            int ySize = coords.Max(c => Math.Max(c.y1, c.y2)) + 1;
            int[,] overlappingCoords = new int[xSize, ySize];

            findOverlappingCoords(coords, overlappingCoords);

            int result = 0;
            for (int i = 0; i < xSize; i++)
                for (int j = 0; j < ySize; j++)
                    if (overlappingCoords[i, j] >= 2) result++;

            return result;
        }

        public static int Part2()
        {
            List<(int x1, int y1, int x2, int y2)> coords = DataService.GetDay5Data();

            int xSize = coords.Max(c => Math.Max(c.x1, c.x2)) + 1;
            int ySize = coords.Max(c => Math.Max(c.y1, c.y2)) + 1;
            int[,] overlappingCoords = new int[xSize, ySize];

            findOverlappingCoords(coords, overlappingCoords, true);

            int result = 0;
            for (int x = 0; x < xSize; x++)
                for (int y = 0; y < ySize; y++)
                    if (overlappingCoords[x, y] >= 2) result++;

            return result;
        }

        private static void findOverlappingCoords(List<(int x1, int y1, int x2, int y2)> coords, int[,] overlappingCoords, bool includeDiagonals = false)
        {
            foreach ((int x1, int y1, int x2, int y2) in coords)
            {
                if (y1 == y2) // horizontal
                {
                    if (x1 < x2)
                    {
                        for (int x = x1; x <= x2; x++)
                            overlappingCoords[x, y1]++;
                    }
                    else
                    {
                        for (int x = x2; x <= x1; x++)
                            overlappingCoords[x, y1]++;
                    }
                }
                else if (x1 == x2) // vertical
                {
                    if (y1 < y2)
                    {
                        for (int y = y1; y <= y2; y++)
                            overlappingCoords[x1, y]++;
                    }
                    else
                    {
                        for (int y = y2; y <= y1; y++)
                            overlappingCoords[x1, y]++;
                    }
                }
                else if (includeDiagonals) // diagonal
                {
                    if (Math.Abs(x1 - x2) != Math.Abs(y1 - y2)) continue;
                    if (x1 < x2)
                    {
                        int y = y1;
                        for (int x = x1; x <= x2; x++)
                        {
                            overlappingCoords[x, y]++;
                            y += y1 < y2 ? 1 : -1;
                        }
                    }
                    else
                    {
                        int y = y2;
                        for (int x = x2; x <= x1; x++)
                        {
                            overlappingCoords[x, y]++;
                            y += y1 > y2 ? 1 : -1;
                        }
                    }
                }
            }
        }
    }
}
