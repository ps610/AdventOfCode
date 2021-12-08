using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal static class DataService
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
                .Select(line => line.ToCharArray()
                    .Select(x => int.Parse(x.ToString())).ToList())
                .ToList();
        }

        public static (List<int> numbers, List<int[,]> boards) GetDay4Data()
        {
            string[] input = File.ReadAllLines(GetDataPath() + @"day4.txt");

            List<int> numbers = input[0].Split(',').Select(int.Parse).ToList();

            List<int[,]> boards = new();
            int[,] currBoard = new int[5, 5];
            int currLine = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Length == 0) continue;

                int currColumn = 0;
                input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x =>
                {
                    currBoard[currLine, currColumn] = int.Parse(x);
                    currColumn++;
                });

                if (currLine + 1 == 5)
                {
                    boards.Add(currBoard);
                    currBoard = new int[5, 5];
                    currLine = 0;
                }
                else
                {
                    currLine++;
                }
            }

            return (numbers, boards);
        }

        public static List<(int x1, int y1, int x2, int y2)> GetDay5Data()
        {
            IEnumerable<int[]> inputCoords = File.ReadAllLines(GetDataPath() + @"day5.txt")
                .Select(line => Regex.Split(line, @"[^\d]+")
                    .Select(int.Parse)
                    .ToArray());

            return inputCoords.Select(i => (x1: i[0], y1: i[1], x2: i[2], y2: i[3]))
                .ToList();
        }

        public static List<int> GetDay6Data()
        {
            return File.ReadAllLines(GetDataPath() + @"day6.txt").First().Split(',').Select(int.Parse).ToList();
        }

        public static List<int> GetDay7Data()
        {
            return File.ReadAllLines(GetDataPath() + @"day7.txt").First().Split(',').Select(int.Parse).ToList();
        }
    }
}
