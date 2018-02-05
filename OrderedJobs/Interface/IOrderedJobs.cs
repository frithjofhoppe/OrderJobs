using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs
{
    public interface IOrderedJobs
    {
        void Register(Job job);
        string Sort();
    }
}
