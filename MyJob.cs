using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Topshelf;

namespace Study.TopshelfDemo
{
    class MyJob:Topshelf.ServiceControl
    {
        readonly Timer _timer;
        public MyJob()
        {
            _timer = new Timer { AutoReset = true, Interval = 2000 };
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"当前时间为：{DateTime.Now}");
        }
        //public void Start() =>_timer.Start();

        //public void Stop() => _timer.Stop();

        public bool Start(HostControl hostControl)
        {
            _timer.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _timer.Stop();
            throw new Exception();
        }
    }
}
