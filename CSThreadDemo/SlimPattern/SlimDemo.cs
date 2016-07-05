using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.SlimPattern
{
    public class SlimDemo
    {
        readonly ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        List<int> _items = new List<int>();
        Random _rand = new Random();

        public SlimDemo()
        { 
        }

        public void Start()
        {
            new Thread(Read).Start();
            new Thread(Read).Start();
            new Thread(Read).Start();

            new Thread(Write).Start("A");
            new Thread(Write).Start("B");
        }

        private void Read()
        {
            while (true)
            {
                _rw.EnterReadLock();

                foreach (int i in _items)
                {
                    Thread.Sleep(10);
                    //Console.Write(" " + i);
                }

                Console.Write("\n");
                Console.WriteLine("Total: " + _items.Count());
                _rw.ExitReadLock();
            }
        }

        private void Write(object threadID)
        {
            while (true)
            {
                int newNumber = GetRandNum(100);
                _rw.EnterWriteLock();
                _items.Add(newNumber);
                _rw.ExitWriteLock();

                Console.WriteLine("Thread " + threadID + " added " + newNumber);
                Console.WriteLine(_rw.CurrentReadCount + " concurrent readers.");
                Thread.Sleep(100);
            }
        }

        private int GetRandNum(int max)
        {
            lock (_rand)
            {
                return _rand.Next(max);
            }
        }
    }
}
