namespace Day9;

public class Program
{
    static void Main(string[] args)
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
        var tailVisited = new HashSet<(int x, int y)>();
        var headPosition = (0, 0);
        var tailPosition = (0, 0);
        
        foreach (var input in inputs)
        {
            var command = input.Split(" ");
            switch (command[0])
            {
                case "R":
                    MoveRight(int.Parse(command[1]), ref headPosition, ref tailPosition, tailVisited);
                    break;
                case "L":
                    MoveLeft(int.Parse(command[1]), ref headPosition, ref tailPosition, tailVisited);
                    break;
                case "U":
                    MoveUp(int.Parse(command[1]), ref headPosition, ref tailPosition, tailVisited);
                    break;
                case "D":
                    MoveDown(int.Parse(command[1]), ref headPosition, ref tailPosition, tailVisited);
                    break;
            }
        }

        return tailVisited.Count;
    }

    private static void MoveRight(int steps, ref (int x, int y) headPosition, ref (int x, int y) tailPosition, HashSet<(int x, int y)> tailVisited)
    {
        for (var i = 0; i < steps; i++)
        {
            headPosition.x++;
            var xDif = headPosition.x - tailPosition.x;
            if (xDif > 1 || xDif < -1)
            {
                tailPosition.x++;
                var yDif = headPosition.y - tailPosition.y;
                if (yDif == 1)
                {
                    tailPosition.y++;
                }
                if (yDif == -1)
                {
                    tailPosition.y--;
                }
            }

            tailVisited.Add(tailPosition);
        }
    }
    
    private static void MoveLeft(int steps, ref (int x, int y) headPosition, ref (int x, int y) tailPosition, HashSet<(int x, int y)> tailVisited)
    {
        for (var i = 0; i < steps; i++)
        {
            headPosition.x--;
            var xDif = headPosition.x - tailPosition.x;
            if (xDif > 1 || xDif < -1)
            {
                tailPosition.x--;
                var yDif = headPosition.y - tailPosition.y;
                if (yDif == 1)
                {
                    tailPosition.y++;
                }
                if (yDif == -1)
                {
                    tailPosition.y--;
                }
            }

            tailVisited.Add(tailPosition);
        }
    }
    
    private static void MoveDown(int steps, ref (int x, int y) headPosition, ref (int x, int y) tailPosition, HashSet<(int x, int y)> tailVisited)
    {
        for (var i = 0; i < steps; i++)
        {
            headPosition.y--;
            var yDif = headPosition.y - tailPosition.y;
            if (yDif > 1 || yDif < -1)
            {
                tailPosition.y--;
                var xDif = headPosition.x - tailPosition.x;
                if (xDif == 1)
                {
                    tailPosition.x++;
                }
                if (xDif == -1)
                {
                    tailPosition.x--;
                }
            }

            tailVisited.Add(tailPosition);
        }
    }
    
    private static void MoveUp(int steps, ref (int x, int y) headPosition, ref (int x, int y) tailPosition, HashSet<(int x, int y)> tailVisited)
    {
        for (var i = 0; i < steps; i++)
        {
            headPosition.y++;
            var yDif = headPosition.y - tailPosition.y;
            if (yDif > 1 || yDif < -1)
            {
                tailPosition.y++;
                var xDif = headPosition.x - tailPosition.x;
                if (xDif == 1)
                {
                    tailPosition.x++;
                }
                if (xDif == -1)
                {
                    tailPosition.x--;
                }
            }

            tailVisited.Add(tailPosition);
        }
    }
    
    private static int Part2(List<string> inputs)
    {
        var tailVisited = new HashSet<(int x, int y)>();
        var positions = new (int x, int y)[10];
        var lastTailVisited = new HashSet<(int x, int y)>();
        
        foreach (var input in inputs)
        {
            var commandLine = input.Split(" ");
            var command = commandLine[0];
            var steps = int.Parse(commandLine[1]);

            var ropeMovement = GetRopeMovement(command);

            for (var i = 0; i < steps; i++)
            {
                positions[0].x += ropeMovement.x;
                positions[0].y += ropeMovement.y;

                for (var j = 1; j < positions.Length; j++)
                {
                    var xDif = positions[j - 1].x - positions[j].x;
                    var yDif = positions[j - 1].y - positions[j].y;

                    if (Math.Abs(xDif) > 1 || Math.Abs(yDif) > 1)
                    {
                        positions[j].x += Math.Sign(xDif);
                        positions[j].y += Math.Sign(yDif);
                    }
                }

                tailVisited.Add(positions[1]);
                lastTailVisited.Add(positions[9]);
            }
        }

        return lastTailVisited.Count();
    }

    private static (int x, int y) GetRopeMovement(string command)
    {
        return command switch
        {
            "R" => (1, 0),
            "L" => (-1, 0),
            "U" => (0, 1),
            "D" => (0, -1),
            _ => throw new ArgumentException()
        };
    }
}