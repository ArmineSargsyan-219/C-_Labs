using System;

class Counter
{
    private static int totalCreated;
    public static int TotalCreated => totalCreated;

    public int ID { get; }

    public Counter()
    {
        totalCreated++;
        ID = totalCreated;

    }
}

class Program
{
    static void Main()
    {
        var c1 = new Counter();
        var c2 = new Counter();
        var c3 = new Counter();

        var counters = new Counter[] { c1, c2, c3 };
        foreach (var c in counters) { 
            Console.WriteLine($"Counter Id: {c.ID}, Total Cretaed: {Counter.TotalCreated}");

        } } }
