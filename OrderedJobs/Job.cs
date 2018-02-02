using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs
{
    class Job
    {
        public char jobA { set; get; }
        public char jobB { set; get; }
        public bool hasDependency { set; get; }
        public bool isHandled { set; get; }

        public Job(char job)
        {
            this.jobA = job;
            this.hasDependency = false;
        }
        public Job(char dependentJob, char indenpendetJob)
        {
            this.jobA = dependentJob;
            this.jobB = indenpendetJob;
            this.hasDependency = true;
        }
    }
}
