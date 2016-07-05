using CSThreadDemo.AbortTest;
using CSThreadDemo.BarrierPattern;
using CSThreadDemo.CountdownEvent;
using CSThreadDemo.EventBasedPattern;
using CSThreadDemo.MonitorPattern;
using CSThreadDemo.SlimPattern;
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

            //Test_ItemQ();

            //Test_Race();

            //Test_Solved();

            //Test_Rendezvous();

            //Test_BarrieDemo();

            //Test_SlimDemo();

            //Test_SlimUpgradeDemo();

            //Test_Abort();

            Test_AbortDemo();

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

        static void Test_Race()
        {
            Race race = new Race();
            race.Start();
        }

        static void Test_Solved()
        {
            Solved race = new Solved();
            race.Start();
        }

        static void Test_Rendezvous()
        {
            Rendezvous rend = new Rendezvous();
            rend.Start();
        }

        static void Test_BarrieDemo()
        {
            BarrieDemo barrie = new BarrieDemo();
            barrie.Start();
        }

        static void Test_SlimDemo()
        {
            SlimDemo slim = new SlimDemo();

            slim.Start();
        }

        static void Test_SlimUpgradeDemo()
        {
            SlimUpgradeDemo slim = new SlimUpgradeDemo();

            slim.Start();
        }

        static void Test_Abort()
        {
            Thread t = new Thread(delegate() { while (true);});

            Console.WriteLine(t.ThreadState);

            t.Start();
            Thread.Sleep(1000);
            Console.WriteLine(t.ThreadState);

            t.Abort();
            Console.WriteLine(t.ThreadState);

            t.Join();
            Console.WriteLine(t.ThreadState);
        }

        static void Test_AbortDemo()
        {
            AbortDemo ad = new AbortDemo();
            ad.Start();
        }
    }
}
