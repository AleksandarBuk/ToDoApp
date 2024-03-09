// Program.cs

class Program {
    private static List<Task> tasks = new List<Task>();
    private static int nextTaskId = 1;

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            DisplayMenu();
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    MarkTaskCompleted();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Delete Task");
        Console.WriteLine("4. Mark Task as completed");
        Console.WriteLine("0. Extin\n");
    }

    static void AddTask()
    {
        Console.WriteLine("Enter task description: ");
        string description = Console.ReadLine();
        Task newTask = new Task
        {
            Id = nextTaskId++,
            description = description,
            isCompleted = false
        };
        tasks.Add(newTask);
        Console.WriteLine("Task added.");
    }

    static void ViewTasks()
    {
        Console.WriteLine("Tasks:");
        foreach (var task in tasks)
        {
            string status = task.isCompleted ? "Complted" : "Pending";
            Console.WriteLine($"ID: {task.Id}, Description: {task.description}, Status: {status}");
        }
    }

    static void DeleteTask()
    {
        Console.WriteLine("Enter task ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            Task taskToRemove = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else{
            Console.WriteLine("Invalid input.");
        }
    }

    static void MarkTaskCompleted()
    {
        Console.WriteLine("Enter task ID to mark as completed:");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            Task taskToComplete = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToComplete != null && !taskToComplete.isCompleted)
            {
                taskToComplete.isCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }
            else if (taskToComplete != null)
            {
                Console.WriteLine("Task is already marked as completed.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

}