using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSThreadDemo.BarrierPattern
{
    public class BarrieDemo
    {
        private Barrier _barrier = new Barrier(3, b => Console.WriteLine());

        public BarrieDemo()
        { 
        }

        public void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                int number = i;
                new Thread(Speak).Start(number);
            }
        }

        private void Speak(object number)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + " - " + number + "      ");
                _barrier.SignalAndWait();
            }
        }
    }
}
