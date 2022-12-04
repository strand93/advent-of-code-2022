namespace Day3;

public class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_3_input1.txt").ToList();

        // var output = Part1(input);
        var output = Part2(input);
        
        Console.WriteLine(output);
        Console.ReadLine(); 
    }

    private static int Part1(List<string> inputs)
    {
        var total = 0;

        foreach (var input in inputs)
        {
            var compartmentOne = input.Substring(0, input.Length / 2);
            var compartmentTwo = input.Substring(input.Length / 2);

            var duplicates = new HashSet<char>();
            foreach (var item in compartmentOne)
            {
                if (duplicates.Contains(item))
                {
                    continue;
                }
                if (compartmentTwo.Contains(item))
                {
                    duplicates.Add(item);
                }
            }

            foreach (var duplicate in duplicates)
            {
                total += GetPriority(duplicate);
            }
        }
        return total;
    }

    private static int GetPriority(char value)
    {
        if (char.IsLower(value))
        {
            return Convert.ToInt32(value) - 96;
        }
        else
        {
            return Convert.ToInt32(value) - 64 + 26;
        }
    }

    private static int Part2(List<string> inputs)
    {
        var total = 0;

        for (int i = 0; i < inputs.Count; i += 3)
        {
            foreach (var value in inputs[i])
            {
                if (inputs[i + 1].Contains(value) && inputs[i + 2].Contains(value))
                {
                    total += GetPriority(value);
                    break;
                }
            }
        }        

        return total;
    }
}