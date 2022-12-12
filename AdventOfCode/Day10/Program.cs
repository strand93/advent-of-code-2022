namespace Day10;

public class Program
{
    static void Main()
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();

        var outputPartOne = Part1(input);
        
        Console.WriteLine("Part 1: " + outputPartOne);
        Console.WriteLine("Part 2: ");
        Console.WriteLine();
        Part2(input);
        
        Console.ReadLine(); 
    }

    private static int Part1(List<string> inputs)
    {
        var cycle = 0;
        var register = 1;
        var signalStrength = 0;

        foreach (var input in inputs)
        {
            var commandLine = input.Split(" ");
            var command = commandLine[0];

            switch (command)
            {
                case "noop":
                    cycle++;
                    signalStrength += CalculateSignalStrength(cycle, register);
                    break;
                case "addx":
                    cycle++;
                    signalStrength += CalculateSignalStrength(cycle, register);
                    cycle++;
                    signalStrength += CalculateSignalStrength(cycle, register);
                    var value = int.Parse(commandLine[1]);
                    register += value;
                    break;
            }

        }
        
        return signalStrength;
    }

    private static int CalculateSignalStrength(int cycle, int register)
    {
        if (cycle == 20 || cycle % 40 == 20)
        {
            return cycle * register;
        }

        return 0;
    }

    private static void Part2(List<string> inputs)
    {
        var cycle = 0;
        var register = 1;
        foreach (var input in inputs)
        {
            var command = input.Split(" ");

            switch (command[0])
            {
                case "noop":
                    DrawCrt(register, cycle);
                    cycle++;
                    break;
                case "addx":
                    DrawCrt(register, cycle);
                    cycle++;
                    DrawCrt(register, cycle);
                    cycle++;
                    register += int.Parse(command[1]);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }

    private static void DrawCrt(int sprite, int cycle)
    {
        cycle %= 40;
        if (cycle == 0)
        {
            Console.WriteLine();
        }
        
        if (sprite == cycle || sprite + 1 == cycle || sprite - 1 == cycle)
        {
            Console.Write("#");
        }
        else
        {
            Console.Write(".");
        }
    }
}