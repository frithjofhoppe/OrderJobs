using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs
{
    class OrderJob : IOrderedJobs
    {
        List<Job> jobs = new List<Job>();
        List<Char> result = new List<Char>();
         
        public void Register(Job job)
        {
            jobs.Add(job);
        }


        public string Sort()
        {
            return charListToString(orderManager());
        }

        private List<Char> orderManager()
        {
            List<Char> back = new List<Char>();
            foreach(Job job in jobs.FindAll(j => j.isHandled == false))
            {
                job.isHandled = true;
                List<Char> temp =  getOrderedTraceByJob(new List<Char>(), job);
                temp.ForEach(chr => result.Add(chr));
            }

            back.Reverse();

            return back;
        }

        private List<Char> getOrderedTraceByJob(List<Char> list ,Job job)
        {
            List<Job> dependencies = searchDependenciesByJob(jobs, job);
            if(!isJobAlreadyOrdered(job.jobA)) list.Add(job.jobA);
            foreach(Job j in dependencies)
            {
                getOrderedTraceByJob(list, new Job(j.jobB));
            }
            return list;
        }

        private String charListToString(List<Char> list)
        {
            String back = "";
            list.ForEach(x => back += x.ToString());
            return back;
        }

        private List<Job> searchDependenciesByJob(List<Job> list, Job job)
        {
            List<Job> result = list.FindAll(x => x.jobA == job.jobA && !(x.jobB == job.jobB));
            result.ForEach(x => x.isHandled = true);
            return result;
        }

        private bool isJobAlreadyOrdered(char toFind)
        {
            if (((int)result.Find(r => r == toFind)) == 0 && ((int)toFind) != 0) return false;
            return true;
        }
    }
}
