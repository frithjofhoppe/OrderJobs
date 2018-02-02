using System;

namespace OrderedJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderJob o = new OrderJob();
            o.Register(new Job('c'));
            o.Register(new Job('b','a'));
            o.Register(new Job('c','b'));
            o.Sort();
        }
    }
}
