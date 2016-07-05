using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.AbortTest
{
    public class AbortDemo
    {
        public AbortDemo()
        { 
        }

        public void Start()
        {
            Thread t = new Thread(Work);
            t.Start();

            Thread.Sleep(1000);
            t.Abort();

            Thread.Sleep(1000);
            t.Abort();

            Thread.Sleep(1000);
            t.Abort();
        }

        private void Work()
        {
            while (true)
            {
                try
                {
                    while (true) ;
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }

                Console.WriteLine("I will not die!");
            }
        }
    }
}
