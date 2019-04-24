using System;
using Topshelf;
namespace Study.TopshelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //HostFactory.Run(hcf =>
            //{
            //    hcf.Service<MyJob>(s =>
            //    {
            //        s.ConstructUsing(name => new MyJob());
            //        //服务启动后
            //        s.WhenStarted(t => t.Start());
            //        //当服务停止的时候
            //        s.WhenStopped(t => t.Stop());
            //    });
            //    hcf.RunAsLocalSystem();
            //    //hcf.RunAsLocalService();
            //    //hcf.RunAsNetworkService();
            //    //显示的服务名称
            //    hcf.SetDisplayName("MyFirstService");
            //    //服务名称
            //    hcf.SetServiceName("MyFirstService");
            //    hcf.SetDescription("这是利用Topshelf开源项目简单方便的快捷生成的服务,服务主要是用于记录日志");
            //});
            HostFactory.Run(hcf =>
            {
                hcf.Service<MyJob>(s =>
                {
                    s.ConstructUsing(name => new MyJob());
                    //----------------------启动-----------------------
                    s.BeforeStartingService(() => Console.WriteLine("服务正在启动中......"));
                    s.AfterStartingService(() => Console.WriteLine("服务启动成功！"));
                    s.WhenStarted((job,hostControl) => job.Start(hostControl));
                    //----------------------停止-----------------------
                    s.BeforeStoppingService(() => Console.WriteLine("服务正在停止中......"));
                    s.AfterStoppingService(() => Console.WriteLine("服务停止成功！"));
                    s.WhenStopped((job, hostControl) => job.Stop(hostControl));
                });
                hcf.RunAsLocalSystem();
                //显示的服务名称
                hcf.SetDisplayName("MyFirstService");
                //服务名称
                hcf.SetServiceName("MyFirstService");
                hcf.SetDescription("这是利用Topshelf开源项目简单方便的快捷生成的服务,服务主要是用于记录日志");
                //--------------------内部服务出现异常---------------------
                hcf.OnException(ex => Console.WriteLine($"MyJob内部错线异常。错误信息：{ex.Message}\r\n堆栈信息：{ex.StackTrace}"));
            });
            //Console.ReadKey();
        }
    }
}
