using System;

public class Task
{
    public string Name { get; }
    public int ExecutionTime { get; } // Time required to complete the task
    public int Period { get; } // Period of the task
    public int TimeRemaining { get; private set; } // Remaining time in the current period
    public bool IsCompleted { get; private set; } = false;

    private Action TaskAction; // Function pointer to the task logic

    public Task(string name, int executionTime, int period, Action taskAction)
    {
        Name = name;
        ExecutionTime = executionTime;
        Period = period;
        TaskAction = taskAction;
        TimeRemaining = executionTime;
    }

    public void Run()
    {
        if (TimeRemaining > 0)
        {
            Console.WriteLine($"Executing {Name}...");
            TaskAction?.Invoke(); // Execute the function
            TimeRemaining--;
            if (TimeRemaining == 0)
            {
                Console.WriteLine($"{Name} completed for this period.");
                IsCompleted = true;
            }
        }
    }

    public void ResetForNextPeriod()
    {
        TimeRemaining = ExecutionTime;
        IsCompleted = false;
    }
}