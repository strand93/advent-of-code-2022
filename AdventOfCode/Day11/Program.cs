namespace Day11;

public class Program
{
    static void Main()
    {
        var input = File.ReadLines(@"..\..\..\AdventCode_input1.txt").ToList();
        // var input = File.ReadLines(@"..\..\..\AdventCode_input1_Test.txt").ToList();

        var outputPartOne = Part1(input);
        var outputPartTwo = Part2(input);
        
        Console.WriteLine("Part 1: " + outputPartOne);
        Console.WriteLine("Part 2: " + outputPartTwo);
        Console.ReadLine(); 
    }

    private static long Part1(List<string> inputs)
    {
        var monkeys = ParseInput(inputs);
        const int rounds = 20;
        
        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                var thrownItems = monkey.Turn();

                foreach (var thrownItem in thrownItems)
                {
                    var catcher = monkeys.First(m => m.Id == thrownItem.monkeyId);
                    catcher.Catch(thrownItem.item);
                }
            }
        }

        var inspectionCount = monkeys.Select(m => m.InspectedCount).ToList();
        inspectionCount.Sort();
        
        return inspectionCount[^1] * inspectionCount[^2];
    }

    private static List<Monkey> ParseInput(List<string> inputs)
    {
        var monkeys = new List<Monkey>();
        Monkey monkey = null!;
        for (var i = 0; i < inputs.Count; i++)
        {
            var input = inputs[i].Trim().Split(" ");
            
            switch ((i+1) % 7)
            {
                case 0:
                    
                    break;
                case 1:
                    var id = int.Parse(input[1].Replace(":", ""));
                    monkey = new Monkey { Id = id };
                    break;
                case 2:
                    var items = new List<Item>();
                    for (int j = 2; j < input.Length; j++)
                    {
                        var worryLevel = int.Parse(input[j].Replace(",", ""));
                        items.Add(new Item
                        {
                            WorryLevel = worryLevel
                        });
                    }
                    monkey.Items = items;
                    break;
                case 3:
                    if (input[5] == "old")
                    {
                        monkey.OperationValue = null;
                    }
                    else if (input[4] == "*")
                    {
                        monkey.OperationMultiplication = true;
                        monkey.OperationValue = int.Parse(input[5]);
                    }
                    else if (input[4] == "+")
                    {
                        monkey.OperationAddition = true;
                        monkey.OperationValue = int.Parse(input[5]);
                    }
                    break;
                case 4:
                    monkey.TestValue = int.Parse(input[3]);
                    break;
                case 5:
                    monkey.MonkeyIfTrue = int.Parse(input[5]);
                    break;
                case 6:
                    monkey.MonkeyIfFalse = int.Parse(input[5]);
                    monkeys.Add(monkey);
                    break;
            }
        }

        return monkeys;
    }
    
    private static long Part2(List<string> inputs)
    {
        var monkeys = ParseInput(inputs);
        const int rounds = 10000;

        var superModulo = monkeys.Aggregate(1, (current, monkey) => current * monkey.TestValue);
        
        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                var thrownItems = monkey.Turn(superModulo);

                foreach (var thrownItem in thrownItems)
                {
                    var catcher = monkeys.First(m => m.Id == thrownItem.monkeyId);
                    catcher.Catch(thrownItem.item);
                }
            }
        }

        var inspectionCount = monkeys.Select(m => m.InspectedCount).ToList();
        inspectionCount.Sort();
        
        return inspectionCount[^1] * inspectionCount[^2];
    }
}