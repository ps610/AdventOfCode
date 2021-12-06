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

        public static (List<int> numbers, List<int[,]> boards) GetDay4Data()
        {
            string[] input = File.ReadAllLines(GetDataPath() + @"day4.txt");

            List<int> numbers = input[0].Split(',').Select(x => int.Parse(x)).ToList();

            List<int[,]> boards = new();
            int[,] currBoard = new int[5, 5];
            int currLine = 0;
            int currColumn = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Length == 0) continue;

                currColumn = 0;
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
    }
}
