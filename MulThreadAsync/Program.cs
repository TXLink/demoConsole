using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MulThreadAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Excute();
            Console.ReadKey();
        }

        public static async void Excute()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " 开始 Excute " + DateTime.Now);
            await SingleAwait();
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " 结束 Excute " + DateTime.Now);
        }


        //使用await等待线程。
        public static async Task SingleAwait()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest 开始 " + DateTime.Now);
            //Console.WriteLine(Thread.CurrentThread.GetHashCode() + " 结束 Excute " + DateTime.Now);
            await Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1" + DateTime.Now);
                Thread.Sleep(1000);

            });

            await Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2" + DateTime.Now);
                Thread.Sleep(1000);
            });

            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest 结束 " + DateTime.Now);

        }

        //使用等待线程结果，等待线程
        public static async Task SigleAwait2()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest 开始 " + DateTime.Now);
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1" + DateTime.Now);
                Thread.Sleep(1000);
            }).GetAwaiter().GetResult();

            Task.Run(()=> {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1" + DateTime.Now);
                Thread.Sleep(1000);
            }).GetAwaiter().GetResult();

            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest 结束 " + DateTime.Now);
            return;
        }

    }
}
