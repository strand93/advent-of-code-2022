using AdventOfCode;

namespace Day8;

public class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();

        var parsedInput = Parser.ParseTo2DInt(input);
        
        var outputPartOne = Part1(parsedInput);
        var outputPartTwo = Part2(parsedInput);
        
        Console.WriteLine("Part 1: " + outputPartOne);
        Console.WriteLine("Part 2: " + outputPartTwo);
        Console.ReadLine(); 
    }

    private static int Part1(int[,] matrix)
    {
        var total = 0;

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var column = 0; column < matrix.GetLength(1); column++)
            {
                if (IsVisible(matrix, row, column))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static bool IsVisible(int [,] matrix, int row, int column)
    {
        if (row == 0 || row == matrix.GetLength(0) - 1 || column == 0 || column == matrix.GetLength(1) - 1)
        {
            return true;
        }

        if (IsVisibleTop(matrix, row, column))
        {
            return true;
        }
        
        if (IsVisibleBot(matrix, row, column))
        {
            return true;
        }
        
        if (IsVisibleLeft(matrix, row, column))
        {
            return true;
        }
        
        if (IsVisibleRight(matrix, row, column))
        {
            return true;
        }

        return false;
    }

    private static bool IsVisibleTop(int[,] matrix, int row, int column)
    {
        for (var i = row - 1; i >= 0; i--)
        {
            if (matrix[row, column] <= matrix[i, column])
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool IsVisibleBot(int[,] matrix, int row, int column)
    {
        for (var i = row + 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[row, column] <= matrix[i, column])
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool IsVisibleLeft(int[,] matrix, int row, int column)
    {
        for (var i = column - 1; i >= 0; i--)
        {
            if (matrix[row, column] <= matrix[row, i])
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool IsVisibleRight(int[,] matrix, int row, int column)
    {
        for (var i = column + 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[row, column] <= matrix[row, i])
            {
                return false;
            }
        }
        return true;
    }

    private static int Part2(int[,] matrix)
    {
        var topScore = 0;
              
        for (var row = 1; row < matrix.GetLength(0) - 1; row++)
        {
            for (var column = 1; column < matrix.GetLength(1) - 1; column++)
            {
                var scenicScore = GetScenicScore(matrix, row, column);
                topScore = scenicScore > topScore ? scenicScore : topScore;
            }
        }
        
        return topScore;   
    }
    
    private static int GetScenicScore(int [,] matrix, int row, int column)
    {
        var top = GetViewDistanceTop(matrix, row, column);
        var bot = GetViewDistanceBot(matrix, row, column);
        var left = GetViewDistanceLeft(matrix, row, column);
        var right = GetViewDistanceRight(matrix, row, column);
        return top * bot * left * right;
    }
    
    private static int GetViewDistanceTop(int[,] matrix, int row, int column)
    {
        var counter = 0;
        for (var i = row - 1; i >= 0; i--)
        {
            counter++;
            if (matrix[row, column] <= matrix[i, column])
            {
                return counter;
            }
        }
        return counter;
    }
    
    private static int GetViewDistanceBot(int[,] matrix, int row, int column)
    {
        var counter = 0;
        for (var i = row + 1; i < matrix.GetLength(0); i++)
        {
            counter++;
            if (matrix[row, column] <= matrix[i, column])
            {
                return counter;
            }
        }
        return counter;
    }
    
    private static int GetViewDistanceLeft(int[,] matrix, int row, int column)
    {
        var counter = 0;
        for (var i = column - 1; i >= 0; i--)
        {
            counter++;
            if (matrix[row, column] <= matrix[row, i])
            {
                return counter;
            }
        }
        return counter;
    }
    
    private static int GetViewDistanceRight(int[,] matrix, int row, int column)
    {
        var counter = 0;
        for (var i = column + 1; i < matrix.GetLength(1); i++)
        {
            counter++;
            if (matrix[row, column] <= matrix[row, i])
            {
                return counter;
            }
        }
        return counter;
    }
}