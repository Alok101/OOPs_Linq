using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApps.Concept
{
    public class Thread_P
    {
        #region Thread
        private static volatile bool _cancel = false;
        public void StartNewThread()
        {
            Thread thread = new Thread(Calculation);
           // thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("Finish Thread");
        }
        public void StartNewThreadJoin()
        {
            Thread thread = new Thread(Calculation);
            thread.Start();
            //while (thread.IsAlive)
            //{
            //    Console.WriteLine("Thread Live IN Between Operation={0}", i++);
            //}
            thread.Join();
            Console.WriteLine("Finish Thread");
        }

        public void ThreadConstructorParams()
        {
            Thread thread = new Thread(Calculation);
            thread.Start("Thread 1 #");
            thread.Join();
            Console.WriteLine("Invoked Thread has been stop");
        }
        public void ThreadDistrupt()
        {
            Thread thread = new Thread(Calculation);
            thread.Start("Thread 1 #");
            Thread.Sleep(5000);
            _cancel = true;
            thread.Join();
            Console.WriteLine("Invoked thread has been stop");
        }
        #endregion
        private void Calculation(object obj)
        {
            string s = obj as string;
            Console.WriteLine("Parameterized thread :{0}",s);
        }
    }

}
