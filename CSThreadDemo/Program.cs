using CSThreadDemo.EventBasedPattern;
using CSThreadDemo.MonitorPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo
{
    class Program
    {
      
        static void Main()
        {
            //Test_BWD()

            //Test_BWEH();

            //Test_MonitorPattern();

            Test_ItemQ();

            Console.ReadLine();
        }

        static void Test_BWD()
        {
            BWDoWork bwd = new BWDoWork();
        }

        static void Test_BWEH()
        {
            BWEventHandler bweh = new BWEventHandler();
            bweh.Init();
        }

        static void Test_MonitorPattern()
        {
            MonitorDemo md = new MonitorDemo();
            md.Start();
        }

        static void Test_ItemQ()
        {
            PCQueue pcq = new PCQueue(5);

            Console.WriteLine("Enqueuing 50 items....");

            for (int i = 0; i < 50; i++)
            {
                int itemNumber = i;
                pcq.EnqueueItem(() => {
                    Thread.Sleep(1000);
                    Console.WriteLine(" Task" + itemNumber);
                });
            }

            pcq.Shutdown(true);
            Console.WriteLine();
            Console.WriteLine("Workers complete!");
        }
    }
}
