namespace Day2;

public class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_2_input1.txt").ToList();

        // var output = Part1(input);
        var output = Part2(input);
        
        Console.WriteLine(output);
        Console.ReadLine(); 
    }

    private static int Part1(List<string> inputs)
    {
        var totalScore = 0;
        foreach (var input in inputs)
        {
            totalScore += CalculateScore(input[0], input[2]);
        }

        return totalScore;
    }

    private static int CalculateScore(char played, char play)
    {
        // A - Rock
        // B - Paper
        // C - Scissors
        // X - Rock 
        // Y - Paper
        // Z - Scissors

        var win = false;
        var loss = false; 
        var draw = false;
        
        switch (played, play)
        {
            case ('A', 'X'):
                draw = true;
                break;
            case ('A', 'Y'):
                win = true;
                break;
            case ('A', 'Z'):
                loss = true;
                break;
            case ('B', 'X'):
                loss = true;
                break;
            case ('B', 'Y'):
                draw = true;
                break;
            case ('B', 'Z'):
                win = true;
                break;
            case ('C', 'X'):
                win = true;
                break;
            case ('C', 'Y'):
                loss = true;
                break;
            case ('C', 'Z'):
                draw = true;
                break;
        }

        var score = 0;

        if (win)
        {
            score += 6;
        }
        else if(draw)
        {
            score += 3;
        }

        if (play == 'X')
        {
            score += 1;
        }
        else if (play == 'Y')
        {
            score += 2;
        }
        else if (play == 'Z')
        {
            score += 3;
        }

        return score;
    }
    
    private static int Part2(List<string> inputs)
    {
        var totalScore = 0;
        foreach (var input in inputs)
        {
            totalScore += CalculateScore2(input[0], input[2]);
        }

        return totalScore;
    }
    
    private static int CalculateScore2(char played, char play)
    {
        // A - Rock
        // B - Paper
        // C - Scissors
        // X - Loss 
        // Y - Draw
        // Z - Win

        var rock = false;
        var paper = false; 
        var scissors = false;
        
        switch (played, play)
        {
            case ('A', 'X'):
                scissors = true;
                break;
            case ('A', 'Y'):
                rock = true;
                break;
            case ('A', 'Z'):
                paper = true;
                break;
            case ('B', 'X'):
                rock = true;
                break;
            case ('B', 'Y'):
                paper = true;
                break;
            case ('B', 'Z'):
                scissors = true;
                break;
            case ('C', 'X'):
                paper = true;
                break;
            case ('C', 'Y'):
                scissors = true;
                break;
            case ('C', 'Z'):
                rock = true;
                break;
        }

        var score = 0;

        if (play == 'Z')
        {
            score += 6;
        }
        else if(play == 'Y')
        {
            score += 3;
        }

        if (rock)
        {
            score += 1;
        }
        else if (paper)
        {
            score += 2;
        }
        else if (scissors)
        {
            score += 3;
        }

        return score;
    }
}