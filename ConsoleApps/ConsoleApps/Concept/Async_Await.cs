using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApps.Concept
{
   public class Async_Await
    {

        private async Task<int> ReadTextCountFromTXT()
        {
            int count = 0;
            using(StreamReader sr=new StreamReader(@"E:\TextTestingFile.txt"))
            {
                var content = await sr.ReadToEndAsync();
                count = content.Length;
            }
            return count;
        }

        //public async void Async_Await_Check()
        //{
        //    Task<int> task = new Task<int>(ReadTextCountFromTXT);
        //    task.Start();
        //    Console.WriteLine("Request in processing....");
        //    int count = await task;
        //    Console.WriteLine("Total Character Length :{0}", count.ToString());
        //    Console.WriteLine("Process Finish");
        //}

        public  async void Async_Await_Return()
        {
            Console.WriteLine("Request Processing Start...");
            int result =await ReadTextCountFromTXT();
            Console.WriteLine("Result={0}", result);
            Console.WriteLine("After Read Text Count From Txt Operation");
          
        }
        public void Async_Await_Task()
        {
            Console.WriteLine("System Input Output Operation={0}", Task_Implementation());
            Console.WriteLine("After System IO Operation={0}", Output());
        }
        private  int Task_Implementation()
        {
            Task<int> t = Task.Run(()=>
            {
                int count = 0;
                using (StreamReader sr = new StreamReader(@"E:\TextTestingFile.txt"))
                {
                    var content = sr.ReadToEnd();
                    count = content.Length;
                }
                return count;
            });
            t.ContinueWith((i) =>
            {
                return i.Result;
            });
            Task<int> t1 = Task.Run(() =>
            {
                int sum = 0;
                for(int i = 0; i < 1000; i++)
                {
                    sum++;
                }
                return sum;
            });
            t1.ContinueWith((i) =>
            {
                Console.WriteLine("Second Task Result={0}", i.Result);
            });
            return t.Result;
        }


        private int Output()
        {
            return 123;
        }
    }
}
