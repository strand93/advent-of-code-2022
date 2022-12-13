namespace Day11;

public class Monkey
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public int? OperationValue { get; set; } 
    public bool OperationAddition { get; set; }
    public bool OperationMultiplication { get; set; }
    public int MonkeyIfTrue { get; set; }
    public int MonkeyIfFalse { get; set; }
    public int TestValue { get; set; }
    public long InspectedCount { get; set; }
    private List<(Item item, int monkeyId)> Throwed { get; set; }
    

    public List<(Item item, int monkeyId)> Turn(int? modulo = null)
    {
        Throwed = new List<(Item item, int monkeyId)>();
        for (int i = 0; i < Items.Count; i++)
        {
            Inspect(Items[i]);
            Relief(Items[i], modulo);
            var monkey = Test(Items[i]);
            Throw(Items[i], monkey);
        }

        foreach (var thrownItem in Throwed)
        {
            Items.Remove(thrownItem.item);
        }

        return Throwed;
    }

    private int Test(Item item)
    {
        return item.WorryLevel % TestValue == 0 ? MonkeyIfTrue : MonkeyIfFalse;
    }

    private void Inspect(Item item)
    {
        InspectedCount++;
        
        if (OperationValue == null)
        {
            item.WorryLevel *= item.WorryLevel;
        }
        else if (OperationAddition)
        {
            item.WorryLevel += OperationValue.Value;
        }
        else if (OperationMultiplication)
        {
            item.WorryLevel *= OperationValue.Value;
        }
    }

    private void Relief(Item item, int? modulo)
    {
        if (modulo == null)
        {
            item.WorryLevel /= 3;
        }
        else
        {
            item.WorryLevel %= modulo.Value;
        }
    }

    private void Throw(Item item, int monkeyId)
    {
        Throwed.Add((item, monkeyId));
    }

    public void Catch(Item item)
    {
        Items.Add(item);
    }
    
}