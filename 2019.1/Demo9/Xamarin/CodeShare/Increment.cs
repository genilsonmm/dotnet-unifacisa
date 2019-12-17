using System;

namespace CodeShare
{
    public class Increment
    {
        private int count;

        public Increment()
        {
            count = 1;
        }
        public int GetNext() => count++;
    }
}
