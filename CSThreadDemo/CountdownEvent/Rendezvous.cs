using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.CountdownEvent
{
    public class Rendezvous
    {
        readonly object _locker = new object();
        Countdown _countdown = new Countdown(2);

        public Rendezvous()
        { 
        }

        public void Start()
        {
            Random r = new Random();
            new Thread(Mate).Start(r.Next(10000));
            Thread.Sleep(r.Next(10000));

            _countdown.Signal();
            _countdown.Wait();

            Console.WriteLine("Mate in parent! ");
        }

        private void Mate(object delay)
        {
            Thread.Sleep((int)delay);

            _countdown.Signal();
            _countdown.Wait();

            Console.WriteLine("Mate in thread!");
        }
    }
}
