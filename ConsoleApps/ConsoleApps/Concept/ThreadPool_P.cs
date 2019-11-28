using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApps.Concept
{
    public class ThreadPool_P
    {
        public void ThreadPoolProgram()
        {
            ThreadPool.QueueUserWorkItem(Calculation,"Hello World");
            Console.WriteLine("Please Enter the thread");
        }

        private void Calculation(object state)
        {
            Console.WriteLine("Invoke Method Value :{0}", state as string);
        }
    }
}
