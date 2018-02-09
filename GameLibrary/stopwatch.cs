using System;
using System.Diagnostics;
using System.Threading;

namespace GameLibrary
{
    class Watch {
        int queueCounter;
        Stopwatch stopwatch;
        Stopwatch timer;
        public string getTime() {
            queueCounter++;
            string str = queueCounter + "    " + stopwatch.Elapsed.ToString() + "      " + timer.Elapsed.TotalMilliseconds.ToString();
            timer.Restart();
            return str;
        }

        public Watch() {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            timer = new Stopwatch();
            timer.Start();
        }
    }
    
}