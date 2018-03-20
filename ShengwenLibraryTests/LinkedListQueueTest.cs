using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShengwenLibrary;

namespace ShengwenLibraryTests
{
    [TestClass]
    public class LinkedListQueueTest
    {
        private readonly LinkedListQueue<string> _queue = new LinkedListQueue<string>();

        [TestMethod]
        public void Enqueue_ExpectedTrue()
        {
            _queue.Enqueue("wo");
            Assert.AreEqual(_queue.Count(), 1);
            _queue.Dequeue();
            Assert.AreEqual(_queue.Count(), 0);
            var sb = new StringBuilder();
            _queue.Enqueue("ni");
            _queue.Enqueue("he");
            _queue.Enqueue("wo");
            _queue.Enqueue("shi");
            _queue.Dequeue();
            _queue.Enqueue("tian");
            _queue.Dequeue();
            _queue.Enqueue("cai");
            foreach (var s in _queue)
            {
                sb.Append(s);
            }
            Assert.AreEqual("woshitiancai",sb.ToString());
            Assert.AreEqual(_queue.Count(), 4);           
        }
    }
    
}
