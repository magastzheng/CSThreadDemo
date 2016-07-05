using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSThreadDemo.EventBasedPattern
{
    public class BWDoWork
    {
        private BackgroundWorker _bw = new BackgroundWorker();

        public BWDoWork()
        {
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerAsync("Message to worker");
        }

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine(e.Argument);
        }
    }
}
