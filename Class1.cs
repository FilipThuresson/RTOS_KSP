using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using UnityEngine;

namespace RTOS_System
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class RTOSSystem: MonoBehaviour
    {
        public static void onStart()
        {
            var scheduler = new Scheduler();

            string name = "Task1";
            int executionTime = 1;
            int period = 10;

            scheduler.AddTask(new Task(name, executionTime, period, Task1));

            scheduler.Start(1000);
        }


        static void Task1()
        {
            //Console.WriteLine("Task1 executed.");
            print("Task1 executed.");
        }
    }
}
