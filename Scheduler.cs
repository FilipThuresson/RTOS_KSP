using System.Collections.Generic;
using System;
using System.Threading;
public class Scheduler
{
    private List<Task> taskList = new List<Task>();
    private Timer systemTimer;
    private int currentTime = 0; // Simulates time in ticks

    public void AddTask(Task task)
    {
        taskList.Add(task);
        // Sort tasks based on their period (shorter period = higher priority)
        taskList.Sort((t1, t2) => t1.Period.CompareTo(t2.Period));
    }

    public void Start(int tickIntervalMs)
    {
        systemTimer = new Timer(Tick, null, 0, tickIntervalMs);
    }

    private void Tick(object state)
    {
        currentTime++;
        Console.WriteLine($"\nSystem Tick: {currentTime}");

        foreach (var task in taskList)
        {
            // Check if the task needs to reset for the next period
            if (currentTime % task.Period == 0)
            {
                task.ResetForNextPeriod();
                Console.WriteLine($"{task.Name} is ready for its next period.");
            }

            // Run the highest-priority task that is not completed
            if (!task.IsCompleted)
            {
                task.Run();
                break; // Only run one task per tick
            }
        }
    }
}