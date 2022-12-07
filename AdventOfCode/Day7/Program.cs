namespace Day7;

public class Program
{
    static void Main()
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();

        var outputPartOne = Part1(input);
        var outputPartTwo = Part2(input);
        
        Console.WriteLine("Part 1: " + outputPartOne);
        Console.WriteLine("Part 2: " + outputPartTwo);
        Console.ReadLine(); 
    }

    private static int Part1(List<string> inputs)
    {
        var sizes = GetDirectorySizes(inputs);
        var total = sizes.Where(size => size <= 100000).Sum();
        
        return total;
    }
    

    private static int Part2(List<string> inputs)
    {
        var sizes = GetDirectorySizes(inputs);

        var spaceLeft = 70000000 - sizes[0];
        var spaceNeededToFree = 30000000 - spaceLeft;

        var smallestDirectorySizeToDelete = int.MaxValue;
        foreach (var size in sizes)
        {
            if (size > spaceNeededToFree && size < smallestDirectorySizeToDelete)
            {
                smallestDirectorySizeToDelete = size;
            }
        }
        
        return smallestDirectorySizeToDelete;
    }

    private static List<int> GetDirectorySizes(List<string> inputs)
    {
        var path = new Stack<string>();
        var sizes = new Dictionary<string, int>();

        foreach (var input in inputs)
        {
            if (input == "$ cd ..")
            {
                path.Pop();
            }
            else if (input.StartsWith("$ cd"))
            {
                var directoryPath = string.Join("", path) + input.Split(" ")[2];
                path.Push(directoryPath);
            }
            else if (input == "$ ls" || input.StartsWith("dir"))
            {
                continue;
            }
            else
            {
                var size = int.Parse(input.Split(" ")[0]);
                foreach (var directory in path)
                {
                    sizes[directory] = sizes.GetValueOrDefault(directory) + size;
                }
            }
        }

        return sizes.Values.ToList();
    }
}