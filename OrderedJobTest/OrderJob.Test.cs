using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace OrderedJobs
{
    [TestClass]
    public class OrderJobTest
    {
        [TestMethod] 
        public void SortJob_WithCircularReferenceDependencies_ThrowsCircurlarReferenceException()
        {
            IOrderedJobs orderJob = new OrderJob();
            orderJob.Register(new Job('a', 'b'));
            orderJob.Register(new Job('b', 'a'));
            NUnit.Framework.Assert.Throws<CircularReferenceException>(() => orderJob.Sort());
        }

        [TestMethod]
        public void SortJob_WithEmptyJob_ThrowsArgumentException()
        {
            IOrderedJobs orderJob = new OrderJob();
            NUnit.Framework.Assert.Throws<ArgumentException>(() => { orderJob.Register(new Job(' '));  });
        }

        [TestMethod]
        public void SortJob_WithNegativLevel_ThrowsArgumentException()
        {
            IOrderedJobs orderJob = new OrderJob();
            NUnit.Framework.Assert.Throws<ArgumentException>(() => { orderJob.Register(new Job('a', -2)); });
        }

        [TestMethod]
        public void SortJob_WithNoJobs_ThrowsOrderJobSortException()
        {
            IOrderedJobs orderJob = new OrderJob();
            NUnit.Framework.Assert.Throws<OrderJobSortException>(() => { orderJob.Sort(); });
        }

        [TestMethod]
        public void SortJob_WithValidJob_ReturnValidOrder()
        {
            IOrderedJobs orderJob = new OrderJob();
            orderJob.Register(new Job('c'));
            orderJob.Register(new Job('b', 'a'));
            orderJob.Register(new Job('c', 'b'));
            NUnit.Framework.Assert.AreEqual(orderJob.Sort(), "abc");
        }
    }
}
