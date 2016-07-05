using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.MonitorPattern
{
    public class PCQueue
    {
        readonly object _locker = new object();
        Thread[] _workers;
        Queue<Action> _itemQ = new Queue<Action>();

        public PCQueue(int workerCount)
        {
            _workers = new Thread[workerCount];

            //create and start a separate thread for each worker
            for (int i = 0; i < workerCount; i++)
            {
                _workers[i] = new Thread(Consume);
                _workers[i].Start();
            }
        }

        public void Shutdown(bool waitForWorkers)
        {
            //Enqueue one null item per worker to make each exit.
            foreach (Thread worker in _workers)
            {
                EnqueueItem(null);
            }

            //wait for workers to finish
            if (waitForWorkers)
            {
                foreach (Thread worker in _workers)
                {
                    worker.Join();
                }
            }
        }

        public void EnqueueItem(Action item)
        {
            lock (_locker)
            {
                _itemQ.Enqueue(item);

                Monitor.Pulse(_locker);
            }
        }

        private void Consume()
        {
            while (true)
            {
                Action item;

                lock (_locker)
                {
                    while (_itemQ.Count == 0)
                    {
                        Monitor.Wait(_locker);
                    }

                    item = _itemQ.Dequeue();
                }

                //This signals our exit
                if (item == null)
                {
                    Console.WriteLine("Exit!!");
                    return;
                }

                item();
            }
        }
    }
}
