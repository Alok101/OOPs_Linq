using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApps.Concept
{
    public class Task_P
    {
        public void TaskProgram()
        {
            Task task = new Task(() =>
              {
                  for (int i = 0; i < 100; i++)
                  {
                      var threadId = Thread.CurrentThread.ManagedThreadId;
                      Console.WriteLine("Task Loop Current Thread Id={0}", threadId);
                  }
              });
            task.Start();
            for (int i = 0; i < 100; i++)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("Main Loop Current Thread Id={0}", threadId);
            }
            task.Wait();
            Console.WriteLine("Finish Execution");
        }

        public void TaskReturnResult()
        {
            Task<int> task = Task.Run(() =>
            {
                return 32;
            });
            Console.WriteLine("Task Return Result ={0}", task.Result);
            Console.WriteLine("Operation Finished");
        }

        public void TaskReturnResultWithContinuation()
        {
            Task<int> t = Task.Run(() =>
            {
                return 32;
            }).ContinueWith((i) => { return i.Result * 2; });
            t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
            });
            Console.WriteLine("Task Operation Completed");
        }

        public void TaskContinuationWithFinalResult()
        {
            Task<int> t = Task.Run(() =>
            {
                return 32;
            });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine("Press Enter to terminate!");
        }

        public void WindowsFormApplication()
        {
            {
                Stopwatch stopWatch = new Stopwatch();
                string result = "";

                var task = new Task(() =>
                {
                    stopWatch.Start();
                    result = Fibo("1000").ToString();
                });

                task.ContinueWith((previousTask) =>
                {
                    Console.WriteLine("Result={0}",result);
                    stopWatch.Stop();
                    Console.WriteLine("Elapsed Time ={0}",(stopWatch.ElapsedMilliseconds / 1000).ToString());
                    stopWatch.Reset();
                },
                TaskScheduler.FromCurrentSynchronizationContext()
                );

                task.Start();
            }
        }
        private ulong Fibo(string nthValue)
        {
            try
            {
                ulong x = 0, y = 1, z = 0, nth, i;
                nth = Convert.ToUInt64(nthValue);
                for (i = 1; i <= nth; i++)
                {
                    z = x + y;
                    x = y;
                    y = z;
                }

                return z;
            }
            catch { }

            return 0;
        }
    }
}
