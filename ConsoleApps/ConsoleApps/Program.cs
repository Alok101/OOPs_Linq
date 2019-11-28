using ConsoleApps.Concept;
using System;

namespace ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Async_Await
           
            Async_Await async_Await = new Async_Await();
            async_Await.Async_Await_Task();
            #endregion


            #region Thread
            //Thread_P thread = new Thread_P();
            //thread.ThreadDistrupt();
            #endregion


            #region ThreadPool
            //ThreadPool_P threadPool_P = new ThreadPool_P();
            //threadPool_P.ThreadPoolProgram();
            #endregion

            #region Thread Race
            //ThreadRaceConditions threadRaceConditions = new ThreadRaceConditions();
            //threadRaceConditions.RaceConditionProgram();
            #endregion

            #region Task
            //Task_P task_P = new Task_P();
            //task_P.WindowsFormApplication();
            #endregion
            Console.WriteLine("Operation Completed");

        }
    }
}
