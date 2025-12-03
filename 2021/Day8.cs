namespace AdventOfCode
{
    public static class Day8
    {
        public static int Part1()
        {
            List<string[][]> input = DataService.GetDay8Data();
            List<string[]> outputPart = input.Select(line => line[1]).ToList();

            int numbers = 0;
            foreach (string[] line in outputPart)
                numbers += line.Sum(digitString => digitString.Length is 2 or 4 or 3 or 7 ? 1 : 0);

            return numbers;
        }

        public static int Part2()
        {
            List<string[][]> input = DataService.GetDay8Data();
            List<int> result = new List<int>();

            foreach (string[][] line in input)
            {
                string[] digitCodes = new string[10];

                // input part
                for (int parseRun = 0; parseRun <= 1; parseRun++) // parse input in 2 runs
                {
                    foreach (string digitString in line[0])
                    {
                        switch (digitString.Length)
                        {
                            case 2:
                                digitCodes[1] = digitString;
                                break;
                            case 3:
                                digitCodes[7] = digitString;
                                break;
                            case 4:
                                digitCodes[4] = digitString;
                                break;
                            case 7:
                                digitCodes[8] = digitString;
                                break;
                            case 5: // 2,3,5
                                if (parseRun == 0)
                                    break;

                                if (digitString.ContainsAllCharsOf(digitCodes[1]))
                                    digitCodes[3] = digitString;
                                else if (digitString.ContainsAllCharsOf(digitCodes[4].Except(digitCodes[7])))
                                    digitCodes[5] = digitString;
                                else
                                    digitCodes[2] = digitString;
                                break;
                            case 6: // 0,6,9
                                if (parseRun == 0)
                                    break;

                                if (digitString.ContainsAllCharsOf(digitCodes[7]) &&
                                    digitString.ContainsAllCharsOf(digitCodes[4]))
                                    digitCodes[9] = digitString;
                                else if (digitString.ContainsAllCharsOf(digitCodes[7]) &&
                                         !digitString.ContainsAllCharsOf(digitCodes[4]))
                                    digitCodes[0] = digitString;
                                else
                                    digitCodes[6] = digitString;
                                break;
                        }
                    }
                }

                // output part
                string numberString = string.Empty;
                foreach (string digitString in line[1])
                {
                    switch (digitString.Length)
                    {
                        case 2:
                            numberString += 1;
                            break;
                        case 3:
                            numberString += 7;
                            break;
                        case 4:
                            numberString += 4;
                            break;
                        case 7:
                            numberString += 8;
                            break;
                        case 5:
                            if (digitString.ContainsAllCharsOf(digitCodes[3]))
                                numberString += 3;
                            else if (digitString.ContainsAllCharsOf(digitCodes[5]))
                                numberString += 5;
                            else
                                numberString += 2;
                            break;
                        case 6:
                            if (digitString.ContainsAllCharsOf(digitCodes[7]) &&
                                digitString.ContainsAllCharsOf(digitCodes[4]))
                                numberString += 9;
                            else if (digitString.ContainsAllCharsOf(digitCodes[7]) &&
                                     !digitString.ContainsAllCharsOf(digitCodes[4]))
                                numberString += 0;
                            else
                                numberString += 6;
                            break;
                    }
                }

                result.Add(int.Parse(numberString));
            }

            return result.Sum();
        }
    }
}