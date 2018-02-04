using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace OrderedJobs
{
    class OrderJob : IOrderedJobs
    {
        List<Job> jobs = new List<Job>();
        List<Char> result = new List<Char>();
        List<Char> tempResult = new List<Char>();
         
        public void Register(Job job)
        {
            jobs.Add(job);
        }


        public string Sort()
        {
            orderManager();
            return charListToString(result);
        }

        private void orderManager()
        {
            bool isOrdering = false;

            if (jobs.Count > 0) { isOrdering = true; }
            try
            {
                while (isOrdering)
                {
                    List<Job> unhandled = jobs.FindAll(j => j.isHandled == false);
                    if (unhandled.Count == 0) { break; }
                    unhandled[0].isHandled = true;
                    List<Job> trace = sortByLevel(getOrderedTraceByJob(new List<Job>(), unhandled[0], 1));
                    trace.Reverse();
                    trace.ForEach(chr => result.Add(chr.jobA));
                }
                result.Reverse();
            }catch(CircularReferenceException exception)
            {
                Console.WriteLine("Zirkelbezug aufgetreten");
                Console.ReadLine();
            }
        }

        private List<Job> getOrderedTraceByJob(List<Job> list ,Job job, int level)
        {
            List<Job> dependencies = searchDependenciesByJob(jobs, job);

            if (hasCircularReferenceOccured(list, job)) throw new CircularReferenceException("Zirkelbezug augetreten");
            if (((int)job.jobA) > 0)
            {
                if (!isJobAlreadyOrdered(list,job.jobA)) { list.Add(new Job(job.jobA, level)); }
            }
            foreach (Job j in dependencies)
            {
                getOrderedTraceByJob(list, new Job(j.jobB), level + 1);
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
            List<Job> result = list.FindAll(x => x.jobA == job.jobA && (((int)x.jobB) > 0));
            result.ForEach(x => x.isHandled = true);
            return result;
        }

        private bool hasCircularReferenceOccured(List<Job> list, Job job)
        {
            List<Job> result = list.FindAll(j => j.jobA == job.jobA && j.level == 1);
            if(result.Count > 0)
            {
                return true;
            }
            return false;
        }

        private List<Job> sortByLevel(List<Job> list)
        {
            return list.OrderByDescending(j => j.level).ToList();
        }

        private bool isJobAlreadyOrdered(List<Job> temporaryList,char toFind)
        {
            bool back = true;
            bool local = true;
            bool global = true;

            if ((((int)result.Find(r => r == toFind)) == 0) && (((int)toFind) != 0)) global = false;
           
            Job j = temporaryList.Find(r => r.jobA == toFind);
            if (j != null)
            {
                if ((int)j.jobA == 0 && (int)toFind != 0) local = false;
            }
            else { local = false; }

            if (!global && !local) back = false;

            return back;
        }
    }
}
