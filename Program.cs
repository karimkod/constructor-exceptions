// See https://aka.ms/new-console-template for more information

// foreach (int _ in Enumerable.Range(0, 5))
// {
//     try
//     {
//         var pos = new Position(1, -1);
//         Console.WriteLine(pos.X);
//         Console.WriteLine(pos.Y);
//     }
//     catch
//     {
//         Console.WriteLine("Exception has been thrown");
//     }
// }
//
// while (Console.ReadKey().Key == ConsoleKey.C)
// {
//     GC.Collect();
// }

try
{
    DumpMemory();
}
catch
{
   Console.WriteLine("File exception caught."); 
}

while (Console.ReadKey().Key == ConsoleKey.C)
{
    GC.Collect();
}

void DumpMemory()
{
    using (var unmanagedMemoryHolder = new MemoryDumper(1024 * 1024 * 1024, ""))
    {
        unmanagedMemoryHolder.DumpToFile();
    }
}

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(x, nameof(x));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(y, nameof(y));

        X = x;
        Y = y;
    }

    ~Position()
    {
        Console.WriteLine("Position has been finalized.");
    }
}
