using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.MonitorPattern
{
    public class Race
    {
        readonly object _locker = new object();
        bool _go;

        public Race()
        { 
        }

        public void Start()
        {
            new Thread(SaySomething).Start();

            for (int i = 0; i < 5; i++)
            {
                lock (_locker)
                {
                    _go = true;
                    Monitor.PulseAll(_locker);
                }
            }
        }

        private void SaySomething(object obj)
        {
            //Only output one and then hangs....
            for (int i = 0; i < 5; i++)
            {
                lock (_locker)
                {
                    while (!_go)
                    {
                        Monitor.Wait(_locker);
                    }

                    _go = false;
                    Console.WriteLine("Wassup?");
                }
            }
        }
    }
}
