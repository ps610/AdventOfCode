using AdventOfCode.data;

namespace AdventOfCode;

public static class Day1
{
    public static int Part1()
    {
        var data = DataService.GetDay1Data();
        var position = 50;
        var countAtZero = 0;
        
        foreach (var move in data)
        {
            if (move.direction == 'L')
                position -= move.value;
            else if (move.direction == 'R')
                position += move.value;

            position %= 100;
            position = (position + 100) % 100;
            
            if (position == 0)
                countAtZero++;
        }
        
        return countAtZero;
    }
    
    public static int Part2()
    {
        var data = DataService.GetDay1Data();
        var position = 50;
        var countAtZero = 0;
        
        foreach (var move in data)
        {
            if (move.direction == 'L')
            {
                var newPosition = (position - move.value % 100 + 100) % 100;
                var fullCycles = move.value / 100;
                countAtZero += fullCycles;
                
                if (position > 0 && move.value % 100 >= position)
                    countAtZero++;
                
                position = newPosition;
            }
            else if (move.direction == 'R')
            {
                var newPosition = (position + move.value % 100) % 100;
                var fullCycles = move.value / 100;
                countAtZero += fullCycles;
                
                if (move.value % 100 > 0 && (newPosition < position || newPosition == 0))
                    countAtZero++;
                
                position = newPosition;
            }
        }
        
        return countAtZero;
    }
}