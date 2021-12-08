namespace AdventOfCode
{
    public static class Day6
    {
        public static int Part1()
        {
            List<int> fish = DataService.GetDay6Data();

            for (int day = 1; day <= 80; day++)
            {
                for (int i = 0; i < fish.Count; i++)
                {
                    switch (fish[i] - 1)
                    {
                        case -1:
                            fish[i] = 6;
                            fish.Add(9);
                            break;
                        default:
                            fish[i]--;
                            break;
                    }
                }
            }

            return fish.Count;
        }

        public static ulong Part2()
        {
            List<int> fish = DataService.GetDay6Data();
            ulong[] fishPerState = new ulong[9];

            foreach (int f in fish)
                fishPerState[Convert.ToUInt64(f)]++;

            for (int day = 1; day <= 256; day++)
            {
                ulong fishStateZero = fishPerState[0];
                for (int i = 0; i < 8; i++)
                    fishPerState[i] = fishPerState[i + 1];

                fishPerState[6] += fishStateZero;
                fishPerState[8] = fishStateZero;
            }

            return fishPerState.Sum(f => f);
        }
    }
}
