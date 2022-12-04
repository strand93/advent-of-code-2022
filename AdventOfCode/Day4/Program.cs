namespace Day4;

public class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();

        var output = Part1(input);
        // var output = Part2(input);
        
        Console.WriteLine(output);
        Console.ReadLine(); 
    }

    private static int Part1(List<string> inputs)
    {
        var total = 0;

        foreach (var input in inputs)
        {
            var elfs = input.Split(',');
            var elfOne = elfs[0];
            var elfTwo = elfs[1];

            var a = elfOne.Split('-');
            var b = elfTwo.Split('-');
            
            var workOrderOne = (int.Parse(a[0]), int.Parse(a[1]));
            var workOrderTwo = (int.Parse(b[0]), int.Parse(b[1]));

            var fullyContainedIn = IsFullyContainedIn(workOrderOne, workOrderTwo);
            fullyContainedIn = fullyContainedIn ? fullyContainedIn : IsFullyContainedIn(workOrderTwo, workOrderOne);

            if (fullyContainedIn)
            {
                total++;
            }
        }

        return total;
    }

    private static bool IsFullyContainedIn((int start, int end) workOrderOne, (int start, int end) workOrderTwo)
    {
        return workOrderOne.start >= workOrderTwo.start && workOrderOne.end <= workOrderTwo.end;
    }

    private static int Part2(List<string> inputs)
    {
        var total = 0;
              
        foreach (var input in inputs)
        {
            var elfs = input.Split(',');
            var elfOne = elfs[0];
            var elfTwo = elfs[1];

            var a = elfOne.Split('-');
            var b = elfTwo.Split('-');
            
            var workOrderOne = (int.Parse(a[0]), int.Parse(a[1]));
            var workOrderTwo = (int.Parse(b[0]), int.Parse(b[1]));

            var overlaps = Overlaps(workOrderOne, workOrderTwo);
            overlaps = overlaps ? overlaps : Overlaps(workOrderTwo, workOrderOne);

            if (overlaps)
            {
                total++;
            }
        }
        return total;
    }
    
    private static bool Overlaps((int start, int end) workOrderOne, (int start, int end) workOrderTwo)
    {
        return workOrderOne.start >= workOrderTwo.start && workOrderOne.start <= workOrderTwo.end;
    }
}