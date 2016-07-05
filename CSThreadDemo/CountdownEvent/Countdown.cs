using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.CountdownEvent
{
    public class Countdown
    {
        readonly object _locker = new object();
        int _count;

        public Countdown()
        { 
        }

        public Countdown(int initialCount)
        {
            _count = initialCount;
        }

        public void Signal()
        {
            AddCount(-1);
        }

        public void Wait()
        {
            lock (_locker)
            {
                while (_count > 0)
                {
                    Monitor.Wait(_locker);
                }
            }
        }

        private void AddCount(int amount)
        {
            lock (_locker)
            {
                _count += amount;

                if (_count <= 0)
                {
                    Monitor.PulseAll(_locker);
                }
            }
        }
        
    }
}
