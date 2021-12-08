namespace AdventOfCode
{
    public static class Day7
    {
        public static int Part1()
        {
            List<int> crabPositions = DataService.GetDay7Data();

            crabPositions = crabPositions.OrderBy(c => c).ToList();
            int middlePosition = crabPositions.Count / 2;

            int fuelCost = 0;
            foreach (int crabPosition in crabPositions)
                fuelCost += Math.Abs(crabPosition - crabPositions[middlePosition]);

            return fuelCost;
        }

        public static int Part2()
        {
            List<(int crabPosition, int crabCount)> crabsPerPosition = DataService.GetDay7Data()
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Count()))
                .ToList();

            int maxPosition = crabsPerPosition.Max(x => x.crabPosition);
            int[] fuelCostsPerPosition = new int[maxPosition + 1];

            foreach ((int crabPosition, int crabCount) in crabsPerPosition)
            {
                for (int i = 0; i <= maxPosition; i++)
                {
                    int distance = Math.Abs(i - crabPosition);
                    fuelCostsPerPosition[i] += (distance * (1 + distance) / 2) * crabCount;
                }
            }

            return fuelCostsPerPosition.Min();
        }
    }
}
