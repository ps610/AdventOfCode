namespace AdventOfCode
{
    internal class DataService
    {
        private static string GetDataPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"/data/";
        }

        public static List<int> GetDay1Data()
        {
            return File.ReadAllLines(GetDataPath() + @"day1.txt")
                .Select(int.Parse)
                .ToList();
        }

        public static List<(string direction, int value)> GetDay2Data()
        {
            return File.ReadAllLines(GetDataPath() + @"day2.txt")
                .Select(x => x.Split(' '))
                .Select(x => (direction: x[0], value: int.Parse(x[1])))
                .ToList();
        }

        public static List<List<int>> GetDay3Data()
        {
            return File.ReadAllLines(GetDataPath() + @"day3.txt")
                .Select(x => x.ToCharArray()
                    .Select(x => int.Parse(x.ToString())).ToList())
                .ToList();
        }
    }
}
