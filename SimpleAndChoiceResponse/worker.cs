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

        public async Task<int> DelayAsync(Stopwatch sw)
        {
            Console.WriteLine("Delay...");
            while (!_shouldStop)
            {
                if (sw.ElapsedMilliseconds >= 5000)
                {
                    RequestStop();
                    return -1;
                }
                Task.Delay(1);
            }
            return 0;
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
