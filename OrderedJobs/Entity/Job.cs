using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs
{
    public class Job
    {
        public char jobA { set; get; }
        public char jobB { set; get; }
        public bool hasDependency { set; get; }
        public bool isHandled { set; get; }
        public int level { get; set; }

        public Job(char job)
        {
            this.jobA = job;
            this.level = 0;
            validateParameters();
        }

        public Job(char job, int level) : this(job)
        {
            this.hasDependency = false;
            this.level = level;
            validateParameters();
        }
        public Job(char dependentJob, char indenpendetJob) : this(dependentJob)
        {
            this.jobB = indenpendetJob;
            this.hasDependency = true;
            validateParameters();
        }

        private bool isCharEmpty(Char c) {
            if (c.ToString().Trim().Length == 1) return false;
            throw new ArgumentException("Job identifier must not be emtpy");
        }

        private void validateParameters()
        {
            isCharEmpty(jobA);
            if (hasDependency) isCharEmpty(jobB);
            if (level < 0) throw new ArgumentException("Job level must not be negativ");
        }
    }
}
