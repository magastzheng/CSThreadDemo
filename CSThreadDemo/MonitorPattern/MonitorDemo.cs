using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.MonitorPattern
{
    public class MonitorDemo
    {
        readonly object _locker = new object();
        bool _go;

        public MonitorDemo()
        { 
        }

        public void Start()
        {
            new Thread(Work).Start();

            Console.ReadLine();

            lock (_locker)
            {
                _go = true;
                Monitor.Pulse(_locker);
            }
        }

        private void Work(object obj)
        {
            lock (_locker)
            {
                while (!_go)
                {
                    Console.WriteLine("Loop for the locker");
                    Monitor.Wait(_locker);
                }
            }

            Console.WriteLine("Woken!!!");
        }
    }
}
