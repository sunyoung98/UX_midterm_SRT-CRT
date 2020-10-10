using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SternbergTest
{
    public class Worker
    {
        private volatile bool _shouldStop = false;

        public async Task DelayAsync(Stopwatch sw)
        {
            Console.WriteLine("Delay...");
            while (!_shouldStop)
            {
                if (sw.ElapsedMilliseconds >= 5000)
                {
                    SendKeys.SendWait("Q");
                }
                Task.Delay(1);
            }
        }
        public void RequestStop()
        {
            Console.WriteLine("request stop...");
            _shouldStop = true;
        }
        public void RequestStart()
        {

            _shouldStop = false;
        }

    }
}
