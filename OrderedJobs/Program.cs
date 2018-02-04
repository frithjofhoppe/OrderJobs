using System;
using System.Windows.Input;
using System.Collections.Generic;

namespace OrderedJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderJob o = new OrderJob();
            //o.Register(new Job('c'));
            //o.Register(new Job('b', 'a'));
            //o.Register(new Job('c', 'b'));
            o.Register(new Job('a', 'b'));
            o.Register(new Job('a', 'c'));
            o.Register(new Job('b', 'f'));
            o.Register(new Job('f', 'a'));
            //o.Register(new Job('d'));
            //o.Register(new Job('c', 'f'));
            //o.Register(new Job('a', 'b'));
            //o.Register(new Job('b', 'a'));
            Console.WriteLine("Reihenfolge: ");

            Char[] result = o.Sort().ToCharArray();

            for(int i = 0; i < result.Length; i++)
            {
                String toWrite = result[i].ToString();
                if (i != result.Length - 1) toWrite += ",";
                Console.Write(toWrite);
            }

            Console.Read();
        }
    }
}
