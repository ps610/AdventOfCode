namespace AdventOfCode
{
    class Day3
    {
        public static int Part1()
        {
            List<List<int>> data = DataService.GetDay3Data();
            List<List<int>> pivot = data.Pivot().Select(x => x.ToList()).ToList();

            string gammaRateBinary = string.Empty;
            string epsilonRateBinary = string.Empty;

            for (int i = 0; i < pivot.Count; i++)
            {
                (int ones, int zeros) = pivot[i].Aggregate((one: 0, zero: 0), (acc, curr) =>
                {
                    if (curr == 0) acc.zero++;
                    if (curr == 1) acc.one++;
                    return acc;
                });

                gammaRateBinary += ones > zeros ? 1 : 0;
                epsilonRateBinary += ones < zeros ? 1 : 0;
            }

            return Convert.ToInt32(gammaRateBinary, 2) * Convert.ToInt32(epsilonRateBinary, 2);
        }

        public static int Part2()
        {
            List<List<int>> data = DataService.GetDay3Data();

            string o2RatingBinary = string.Join(string.Empty, Filter(data, true));
            string co2RatingBinary = string.Join(string.Empty, Filter(data, false));

            return Convert.ToInt32(o2RatingBinary, 2) * Convert.ToInt32(co2RatingBinary, 2);
        }

        private static List<int> Filter(List<List<int>> data, bool mostCommon, int index = 0)
        {
            int mostCommonNumber = data.Select(x => x[index])
                .OrderByDescending(x => x)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .First();

            List<List<int>> dataFiltered = mostCommon ? data.Where(x => x[index] == mostCommonNumber).ToList() : data.Where(x => x[index] != mostCommonNumber).ToList();

            return dataFiltered.Count == 1 ? dataFiltered.First() : Filter(dataFiltered, mostCommon, index += 1);
        }
    }
}
