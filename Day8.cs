namespace AdventOfCode
{
    public static class Day8
    {
        public static int Part1()
        {
            List<string[][]> input = DataService.GetDay8Data();

            int[] numbers = new int[10];
            foreach (string[][] line in input)
            {
                foreach (string digit in line.Last())
                {
                    switch (digit.Length)
                    {
                        case 2:
                            numbers[1]++;
                            break;
                        case 4:
                            numbers[4]++;
                            break;
                        case 3:
                            numbers[7]++;
                            break;
                        case 7:
                            numbers[8]++;
                            break;
                    }
                }
            }

            return numbers.Sum();
        }

        public static int Part2()
        {
            //var input = DataService.GetDay8Data();

            return 0;
        }
    }
}