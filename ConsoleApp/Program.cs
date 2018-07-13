using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ////第一种方式
            //Stopwatch watch = Stopwatch.StartNew();
            //Console.WriteLine("begin---");
            //var task1 = Task.Run(() =>
            //{
            //    return HttpService.PostData("", "http://localhost:55568/home/getmsg2");
            //});
            //var task2 = Task.Run(() =>
            //{

            //    return HttpService.PostData("", "http://localhost:55568/home/getmsg1");
            //});
            //Console.WriteLine("我是主业务--");
            //Task.WaitAll(task1, task2);
            //Console.WriteLine($"{task1.Result},{task2.Result}");
            //watch.Stop();
            //Console.WriteLine($"耗时：{watch.ElapsedMilliseconds}");

            ////第二种方式
            //Stopwatch watch = Stopwatch.StartNew();
            //HttpClient http = new HttpClient();
            //var httpcontent = new StringContent("", Encoding.UTF8, "application/json");
            //Console.WriteLine("begin---");
            //var r1 = http.PostAsync("http://localhost:55568/home/getmsg1", httpcontent);
            //var r2 = http.PostAsync("http://localhost:55568/home/getmsg2", httpcontent);
            //Console.WriteLine("我是主业务--");
            //Console.WriteLine(r2.Result.Content.ReadAsStringAsync().Result);
            //Console.WriteLine(r1.Result.Content.ReadAsStringAsync().Result);
            //watch.Stop();
            //Console.WriteLine($"耗时：{watch.ElapsedMilliseconds}");

            ////第三种方式
            //Stopwatch watch = Stopwatch.StartNew();
            //Console.WriteLine("开始执行");
            //Task<string> t1 = GetMsg1();
            //Task<string> t2 = GetMsg2();
            //Console.WriteLine("我是主业务");
            //Console.WriteLine($"{t1.Result},{t2.Result}");
            //watch.Stop();
            //Console.WriteLine($"耗时：{watch.ElapsedMilliseconds}");


            ////第四种方式
            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("开始执行");
            Task<string> t1 = GetMsg11();
            Task<string> t2 = GetMsg22();
            Console.WriteLine("我是主业务");
            Console.WriteLine($"{t1.Result},{t2.Result}");
            watch.Stop();
            Console.WriteLine($"耗时：{watch.ElapsedMilliseconds}");

            Console.ReadKey();
        }

        private static async Task<string> GetMsg1()
        {
            HttpClient http = new HttpClient();
            var httpcontent = new StringContent("", Encoding.UTF8, "application/json");
            var r1 = await http.PostAsync("http://localhost:55568/home/getmsg1", httpcontent);
            return r1.Content.ReadAsStringAsync().Result;
        }
        private static async Task<string> GetMsg2()
        {
            HttpClient http = new HttpClient();
            var httpcontent = new StringContent("", Encoding.UTF8, "application/json");
            var r1 = await http.PostAsync("http://localhost:55568/home/getmsg2", httpcontent);
            return r1.Content.ReadAsStringAsync().Result;
        }


        public static async Task<string> GetMsg11()
        {
            var msg = await Task.Run(() =>
            {
                return HttpService.PostData("", "http://localhost:55568/home/getmsg1");
            });
            return msg;
        }

        public static async Task<string> GetMsg22()
        {
            var msg = await Task.Run(() =>
            {
                return HttpService.PostData("", "http://localhost:55568/home/getmsg2");
            });
            return msg;
        }

    }
}
