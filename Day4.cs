namespace AdventOfCode
{
    public class Day4
    {
        public static int Part1()
        {
            (List<int> numbers, List<int[,]> boards) = DataService.GetDay4Data();

            (int[,] winningBoard, int winningNumberCall) = DetermineWinningBoard(numbers, boards, true);

            int sumOfRemainingBoardNumbers = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    sumOfRemainingBoardNumbers += winningBoard[i, j] != -1 ? winningBoard[i, j] : 0;

            return sumOfRemainingBoardNumbers * winningNumberCall;
        }

        public static int Part2()
        {
            (List<int> numbers, List<int[,]> boards) = DataService.GetDay4Data();

            (int[,] winningBoard, int winningNumberCall) = DetermineWinningBoard(numbers, boards, false);

            int sumOfRemainingBoardNumbers = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    sumOfRemainingBoardNumbers += winningBoard[i, j] != -1 ? winningBoard[i, j] : 0;

            return sumOfRemainingBoardNumbers * winningNumberCall;
        }

        private static (int[,] winningBoard, int winningNumberCall) DetermineWinningBoard(List<int> numbers, List<int[,]> boards, bool first)
        {
            const int bingoMatch = -1;
            bool[] bingoPerBoard = new bool[boards.Count];
            int[] bingoInRoundPerBoard = new int[boards.Count];
            int[] matchesPerBoard = new int[boards.Count];

            for (int n = 0; n < numbers.Count; n++)
            {
                for (int b = 0; b < boards.Count; b++)
                {
                    if (bingoPerBoard[b]) continue;

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (boards[b][i, j] == numbers[n])
                            {
                                boards[b][i, j] = bingoMatch;
                                matchesPerBoard[b]++;
                            }
                        }
                    }

                    if (matchesPerBoard[b] >= 5)
                    {
                        int i = 0;
                        while (i < 5 && !bingoPerBoard[b])
                        {
                            if (boards[b][0, i] == bingoMatch &&
                                boards[b][1, i] == bingoMatch &&
                                boards[b][2, i] == bingoMatch &&
                                boards[b][3, i] == bingoMatch &&
                                boards[b][4, i] == bingoMatch)
                            {
                                bingoPerBoard[b] = true;
                                bingoInRoundPerBoard[b] = n;
                            }
                            if (boards[b][i, 0] == bingoMatch &&
                                boards[b][i, 1] == bingoMatch &&
                                boards[b][i, 2] == bingoMatch &&
                                boards[b][i, 3] == bingoMatch &&
                                boards[b][i, 4] == bingoMatch)
                            {
                                bingoPerBoard[b] = true;
                                bingoInRoundPerBoard[b] = n;
                            }
                            i++;
                        }
                    }
                }
            }

            int winningBoardIndex = 0;
            for (int i = 0; i < bingoInRoundPerBoard.Length; i++)
            {
                if (first)
                {
                    if (bingoInRoundPerBoard[i] < bingoInRoundPerBoard[winningBoardIndex]) winningBoardIndex = i;
                }
                else
                {
                    if (bingoInRoundPerBoard[i] > bingoInRoundPerBoard[winningBoardIndex]) winningBoardIndex = i;
                }
            }

            return (boards[winningBoardIndex], numbers[bingoInRoundPerBoard[winningBoardIndex]]);
        }
    }
}
