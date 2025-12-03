using System.Reflection;

namespace AdventOfCode.data;

public static class DataService
{
    private static string GetDataPath() 
        => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/data/";
    
    public static List<(char direction, int value)> GetDay1Data()
    {
        // first character is direction, rest is value
        return File.ReadAllLines(GetDataPath() + "day1.txt")
            .Select(x => (direction: x[0], value: int.Parse(x.Substring(1))))
            .ToList();
    }
}