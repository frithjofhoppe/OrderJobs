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
        public int level { get; set; }

        public Job(char job)
        {
            this.jobA = job;
            this.hasDependency = false;
            this.level = 0;
        }

        public Job(char job, int level)
        {
            this.jobA = job;
            this.hasDependency = false;
            this.level = level;
        }
        public Job(char dependentJob, char indenpendetJob)
        {
            this.level = 1;
            this.jobA = dependentJob;
            this.jobB = indenpendetJob;
            this.hasDependency = true;
        }
    }
}
