namespace Day6;

public class Program
{
    static void Main()
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();

        var outputPartOne = Part1(input[0]);
        var outputPartTwo = Part2(input[0]);
        
        Console.WriteLine("Part 1: " + outputPartOne);
        Console.WriteLine("Part 2: " + outputPartTwo);
        Console.ReadLine(); 
    }

    private static int Part1(string subroutine)
    {
        var marker = new Queue<char>();
        for (var i = 0; i < subroutine.Length; i++)
        {
            marker.Enqueue(subroutine[i]);
            if (i < 3)
            {
                continue;
            }

            if (IsValidMarker(marker))
            {
                return i + 1;
            }

            marker.Dequeue();
        }

        throw new Exception();
    }

    private static bool IsValidMarker(Queue<char> marker)
    {
        var tempMarker = new HashSet<char>();

        foreach (var value in marker)
        {
            if (!tempMarker.Add(value))
            {
                return false;
            }
        }
        
        return true;
    }

    private static int Part2(string subroutine)
    {
        var marker = new Queue<char>();
        for (var i = 0; i < subroutine.Length; i++)
        {
            marker.Enqueue(subroutine[i]);
            if (i < 13)
            {
                continue;
            }

            if (IsValidMarker(marker))
            {
                return i + 1;
            }

            marker.Dequeue();
        }
        
        throw new Exception();
    }
}