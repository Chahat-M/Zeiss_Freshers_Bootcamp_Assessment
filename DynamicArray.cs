public class DynamicArray<T>
{
    private List<T> list;
    public DynamicArray(uint initialCapacity)
    {
        list = new List<T>((int)initialCapacity);
    }

    public void Add(uint index, T value)
    {
        if (index > list.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        list.Insert((int)index, value);
    }

    public int Count { get { return list.Count; } }

    public T this[uint index]
    {
        get
        {
            if (index > list.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return list[(int)index];
        }
    }
}


public class Program
{
    static void Main()
    {
        DynamicArray<int> numbers = new DynamicArray<int>(2);
        numbers.Add(0, 100);
        numbers.Add(1, 200);
        numbers.Add(2, 300);
        numbers.Add(3, 400);
        int value = numbers[2];
        System.Console.WriteLine($"Total Number Of Items in Array:{numbers.Count} ,Value:{value} at index:2");

        DynamicArray<string> stringItems = new DynamicArray<string>(2);
        stringItems.Add(0, "100");
        stringItems.Add(1, "200");
        stringItems.Add(2, "300");
        stringItems.Add(3, "400");
        string itemValue = stringItems[3];
        System.Console.WriteLine($"Total Number Of Items in Array:{stringItems.Count} , Value:{itemValue} at index:3");
    }
}
