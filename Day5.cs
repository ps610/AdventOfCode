namespace AdventOfCode
{
    public class Day5
    {
        public static int Part1()
        {
            List<(int x1, int y1, int x2, int y2)> coords = DataService.GetDay5Data();

            int xSize = coords.Max(c => Math.Max(c.x1, c.x2));
            int ySize = coords.Max(c => Math.Max(c.y1, c.y2));
            int[,] overlappingCoords = new int[xSize + 1, ySize + 1];

            for (int i = 0; i < coords.Count; i++)
            {
                if (coords[i].y1 == coords[i].y2)
                {
                    if (coords[i].x1 > coords[i].x2)
                    {
                        for (int j = coords[i].x2; j < coords[i].x1 + 1; j++)
                            overlappingCoords[j, coords[i].y1]++;
                    }
                    if (coords[i].x2 > coords[i].x1)
                    {
                        for (int j = coords[i].x1; j < coords[i].x2 + 1; j++)
                            overlappingCoords[j, coords[i].y1]++;
                    }
                }
                if (coords[i].x1 == coords[i].x2)
                {
                    if (coords[i].y1 > coords[i].y2)
                    {
                        for (int j = coords[i].y2; j < coords[i].y1 + 1; j++)
                            overlappingCoords[coords[i].x1, j]++;
                    }
                    if (coords[i].y2 > coords[i].y1)
                    {
                        for (int j = coords[i].y1; j < coords[i].y2 + 1; j++)
                            overlappingCoords[coords[i].x1, j]++;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < xSize + 1; i++)
                for (int j = 0; j < ySize + 1; j++)
                    if (overlappingCoords[i, j] >= 2) result++;

            return result;
        }

        public static int Part2()
        {
            //List<(int x1, int y1, int x2, int y2)> coords = DataService.GetDay5Data();

            return 0;
        }
    }
}
