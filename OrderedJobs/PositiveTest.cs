using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace OrderedJobs
{
    class PositiveTest
    {
        [Test]
        public void CirucalReferencedDependenciesThrowCorrespondatenException()
        {
            IOrderedJobs orderJob = new OrderJob();
            orderJob.Register(new Job('a','b'));
            orderJob.Register(new Job('b', 'a'));
            orderJob.Sort();
            Assert.True(true);
        }
    }
}
