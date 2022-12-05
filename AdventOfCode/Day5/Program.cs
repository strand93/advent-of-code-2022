namespace Day5;

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

    private static string Part1(List<string> inputs)
    {
        var stacksOfCrates = GetStacks();

        for (int i = 10; i < inputs.Count; i++)
        {
            var instructions = inputs[i].Split(" ");
            
            MoveCrates(stacksOfCrates, int.Parse(instructions[1]), int.Parse(instructions[3]), int.Parse(instructions[5]));
        }

        var message = GetMessage(stacksOfCrates);

        return message;
    }

    private static string GetMessage(List<Stack<string>> stacksOfCrates)
    {
        return stacksOfCrates.Aggregate("", (current, crates) => current + crates.Peek());
    }

    private static void MoveCrates(List<Stack<string>> stacksOfCrates, int move, int from, int to)
    {
        for (int i = 0; i < move; i++)
        {
            stacksOfCrates[to-1].Push(stacksOfCrates[from-1].Pop());
        }
    }

    private static string Part2(List<string> inputs)
    {
        var stacksOfCrates = GetStacks();

        for (int i = 10; i < inputs.Count; i++)
        {
            var instructions = inputs[i].Split(" ");
            
            MoveCratesSameOrder(stacksOfCrates, int.Parse(instructions[1]), int.Parse(instructions[3]), int.Parse(instructions[5]));
        }

        var message = GetMessage(stacksOfCrates);

        return message;
    }
    
    private static void MoveCratesSameOrder(List<Stack<string>> stacksOfCrates, int move, int from, int to)
    {
        var tempStack = new Stack<string>();
        for (int i = 0; i < move; i++)
        {
            tempStack.Push(stacksOfCrates[from-1].Pop());
        }

        for (int i = 0; i < move; i++)
        {
            stacksOfCrates[to-1].Push(tempStack.Pop());
        }
    }

    private static List<Stack<string>> GetTestStacks()
    {
        var stackOfCrates = new List<Stack<string>>
        {
            new Stack<string>(new []{"Z", "N"}),
            new Stack<string>(new []{"M", "C", "D"}),
            new Stack<string>(new []{"P"})
        };

        return stackOfCrates;
    }
    
    private static List<Stack<string>> GetStacks()
    {
        var stackOfCrates = new List<Stack<string>>
        {
            new Stack<string>(new []{"Q", "M", "G", "C", "L"}),
            new Stack<string>(new []{"R", "D", "L", "C", "T", "F", "H", "G"}),
            new Stack<string>(new []{"V", "J", "F", "N", "M", "T", "W", "R"}),
            new Stack<string>(new []{"J", "F", "D", "V", "Q", "P"}),
            new Stack<string>(new []{"N", "F", "M", "S", "L", "B", "T"}),
            new Stack<string>(new []{"R", "N", "V", "H", "C", "D", "P"}),
            new Stack<string>(new []{"H", "C", "T"}),
            new Stack<string>(new []{"G", "S", "J", "V", "Z", "N", "H", "P"}),
            new Stack<string>(new []{"Z", "F", "H", "G"})
        };

        return stackOfCrates;
    }
}