namespace PizzaPluseYummyYummy;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var p1 = new Pizza("P1", 10000);
        var p2 = new Pizza("P2", 20000);
        var p3 = new Pizza("P3", 30000);

        // Wait asynchronously for all pizza cooking tasks to complete
        await Task.WhenAll(
            CookPizza(p1),
            CookPizza(p2),
            CookPizza(p3)
        );
    }

    private static async Task CookPizza(Pizza pizza)
    {
        var bakeTime = pizza.BakingTime;
        var interVal = 10000;
        while (bakeTime > 0)
        {
            Console.WriteLine($"{pizza.Name} is baking: time left: {bakeTime}");
            await Task.Delay(interVal);
            bakeTime -= interVal;
        }
        Console.WriteLine($"Yummy yummy {pizza.Name} is ready");
    }
}

internal class Pizza
{
    public string Name { get; set; }
    public int BakingTime { get; set; }

    public Pizza(string name, int bakeTime)
    {
        Name = name;
        BakingTime = bakeTime;
    }
}

