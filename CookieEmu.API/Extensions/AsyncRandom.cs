using System;
using System.Threading;

namespace CookieEmu.API.Extensions
{
    public sealed class AsyncRandom : Random
    {
        private static int _incrementer;
        public AsyncRandom()
            : base(Environment.TickCount + Thread.CurrentThread.ManagedThreadId + _incrementer)
        {
            Interlocked.Increment(ref _incrementer);
        }

        public AsyncRandom(int seed)
            : base(seed)
        {
        }

        public double NextDouble(double min, double max)
        {
            return NextDouble() * (max - min) + min;
        }
    }
}
