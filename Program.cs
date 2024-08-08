namespace PizzaPluseYummyYummy;

class Program
{
    static async Task Main(string[] args)
    {
        // Run ExecuteTasks in a loop
        await RunTasksInLoop(100);
    }

    static async Task ExecuteTasks()
    {
        Task<int> task1 = Task.Run(async () => { await Task.Delay(30); return 3; });
        Task<int> task2 = Task.Run(async () => { await Task.Delay(20); return 2; });
        Task<int> task3 = Task.Run(async () => { await Task.Delay(10); return 1; });

        Task<Task<int>> firstCompletedTask = Task.WhenAny(task1, task2, task3);

        Task<int> completedTask = await firstCompletedTask;
        int result = await completedTask;

        Console.WriteLine($"The first task completed with result: {result}");
    }

    static async Task RunTasksInLoop(int loops)
    {
        for (int i = 0; i < loops; i++)
        {
            //Console.WriteLine("Starting task execution...");
            await ExecuteTasks();
            //Console.WriteLine("Tasks completed. Waiting 5 seconds before starting again...");

        }
    }
}

