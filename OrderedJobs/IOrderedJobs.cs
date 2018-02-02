using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs
{
    interface IOrderedJobs
    {
        void Register(Job job);
        string Sort();
    }
}
