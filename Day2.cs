namespace AdventOfCode
{
    public class Day2
    {
        public static (int horizontal, int depth) Part1()
        {
            List<(string direction, int value)> data = DataService.GetDay2Data();
            int horizontal = 0;
            int depth = 0;

            foreach ((string direction, int value) in data)
            {
                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    case "down":
                        depth += value;
                        break;
                }
            }

            return (horizontal, depth);
        }

        public static (int horizontal, int depth, int aim) Part2()
        {
            List<(string direction, int value)> data = DataService.GetDay2Data();
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach ((string direction, int value) in data)
            {
                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        depth += aim * value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                }
            }

            return (horizontal, depth, aim);
        }
    }
}
