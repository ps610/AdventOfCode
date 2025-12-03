namespace AdventOfCode
{
    public static class Day10
    {
        private const char LineNotCorrupted = 'x';
        private const string LineAlreadyComplete = "already complete";

        private static readonly Dictionary<char, char> ChunkBoundariesByOpening = new Dictionary<char, char>()
        {
            {'{', '}'},
            {'(', ')'},
            {'<', '>'},
            {'[', ']'}
        };

        private static readonly Dictionary<char, char> ChunkBoundariesByClosing =
            ChunkBoundariesByOpening.ToDictionary(x => x.Value, x => x.Key);

        public static int Part1()
        {
            List<string> input = DataService.GetDay10Data();

            Dictionary<char, int> chunkBoundariesScores = new Dictionary<char, int>()
            {
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137},
                {LineNotCorrupted, 0}
            };

            return input.Sum(line => chunkBoundariesScores[FindFirstCorruptedBoundaryInLine(line)]);
        }

        public static ulong Part2()
        {
            List<string> input = DataService.GetDay10Data();

            Dictionary<char, int> chunkBoundariesScores = new Dictionary<char, int>()
            {
                {')', 1},
                {']', 2},
                {'}', 3},
                {'>', 4}
            };

            List<string> chunksToCompleteLines = input
                .Select(CompleteLineWithMissingClosingBoundaries)
                .Where(x => x != LineAlreadyComplete)
                .ToList();

            List<ulong> incompleteScores = chunksToCompleteLines
                .Select(line =>
                    line.Aggregate<char, ulong>(0, (current, c) =>
                        current * 5 + Convert.ToUInt64(chunkBoundariesScores[c]))
                ).ToList();

            return incompleteScores.OrderBy(x => x).ToList()[incompleteScores.Count / 2];
        }

        private static Stack<char> FindUnclosedBoundariesInLine(string line)
        {
            Stack<char> openingBoundaries = new Stack<char>();

            foreach (char boundary in line)
            {
                if (boundary is '{' or '[' or '<' or '(')
                    openingBoundaries.Push(boundary);
                else
                {
                    char lastOpeningBoundary = openingBoundaries.Pop();
                    if (ChunkBoundariesByClosing[boundary] != lastOpeningBoundary)
                        throw new Exception(boundary.ToString());
                }
            }

            return openingBoundaries;
        }

        private static char FindFirstCorruptedBoundaryInLine(this string line)
        {
            try
            {
                FindUnclosedBoundariesInLine(line);
                return LineNotCorrupted;
            }
            catch (Exception ex)
            {
                return ex.Message[0];
            }
        }

        private static string CompleteLineWithMissingClosingBoundaries(string line)
        {
            string closingBoundariesToComplete = string.Empty;

            try
            {
                Stack<char> unclosedBoundaries = FindUnclosedBoundariesInLine(line);
                while (unclosedBoundaries.Count > 0)
                    closingBoundariesToComplete += ChunkBoundariesByOpening[unclosedBoundaries.Pop()];
            }
            catch (Exception)
            {
                return LineAlreadyComplete;
            }

            return closingBoundariesToComplete;
        }
    }
}