using System;
using System.Threading;
namespace ConsoleApps.Concept
{
    public class ThreadRaceConditions
    {
        private int sum = 0;
        public void RaceConditionProgram()
        {
            
            //create thread t1 using anonymous method
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    //increment sum value
                 Console.WriteLine("Thread 1 :{0}",sum++);
                }
            });

            //create thread t2 using anonymous method
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    //increment sum value
                    Console.WriteLine("Thread 2 :{0}", sum++);
                }
            });


            //start thread t1 and t2
            t1.Start();
            t2.Start();

            //wait for thread t1 and t2 to finish their execution
            t1.Join();
            t2.Join();
            Console.WriteLine("Sum={0}", sum);
            Console.WriteLine("Thread Completed");
        }
    }
}
