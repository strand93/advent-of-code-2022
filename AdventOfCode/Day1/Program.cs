namespace Day1;

public class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_1_input1.txt").ToList();

        // var output = Part1(input);
        var output = Part2(input);
        
        Console.WriteLine(output);
        Console.ReadLine(); 
    }

    private static int Part1(List<string> elfs)
    {
        var maxCaloriesCount = 0;
        var tempCount = 0;
        
        for (var i = 0; i < elfs.Count; i++)
        {
            if (elfs[i] == "")
            {
                if (tempCount > maxCaloriesCount)
                {
                    maxCaloriesCount = tempCount;
                }

                tempCount = 0;
                continue;
            }
            tempCount += int.Parse(elfs[i]);
        }
        
        return maxCaloriesCount;
    }
    
    private static int Part2(List<string> elfs)
    {
        var tempCount = 0;
        var top3CaloriesCount = new List<int>();
        
        for (var i = 0; i < elfs.Count; i++)
        {
            if (elfs[i] == "")
            {
                if (top3CaloriesCount.Count < 3)
                {
                    top3CaloriesCount.Add(tempCount);
                    tempCount = 0;
                    continue;
                }

                top3CaloriesCount.Sort();
                if (tempCount > top3CaloriesCount[0])
                {
                    top3CaloriesCount[0] = tempCount;
                }
                tempCount = 0;
                continue;
            }
            tempCount += int.Parse(elfs[i]);
        }

        return top3CaloriesCount.Sum();
    }
}