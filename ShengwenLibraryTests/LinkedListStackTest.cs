using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShengwenLibrary;

namespace ShengwenLibraryTests
{
    [TestClass]
    public class LinkedListStackTest
    {
        private readonly LinkedListStack<string> _teStack = new LinkedListStack<string>();
        [TestMethod]
        public void Push_pushToEmpty_expectTrue()
        {
            _teStack.Push("wo");
            Assert.AreEqual(_teStack.Peek(),"wo");
            Assert.AreEqual(_teStack.Count(), 1);
        }
        [TestMethod]
        public void Pop_popOnly1Item_expectTrue()
        {
            _teStack.Push("wo");
            Assert.AreEqual(_teStack.Peek(), "wo");
            Assert.AreEqual(_teStack.Count(), 1);
            Assert.AreEqual(_teStack.Pop(), "wo");
            Assert.AreEqual(_teStack.Count(), 0);
        }
        [TestMethod]
        public void Push_push2words_expectedTrue()
        {
            _teStack.Push("wo");
            _teStack.Push("bu");
            Assert.AreEqual(_teStack.Count(), 2);
        }
        [TestMethod]
        public void Pop_popbu_expectTrue()
        {
            _teStack.Push("wo");
            _teStack.Push("bu");
            Assert.AreEqual(_teStack.Count(), 2);
            Assert.AreEqual(_teStack.Pop(), "bu");
            Assert.AreEqual(_teStack.Count(), 1);
        }
        [TestMethod]
        public void Enumerator_expectTrue()
        {
            _teStack.Push("wo");
            _teStack.Push("shi");
            _teStack.Push("tian");
            _teStack.Push("cai");
            StringBuilder sb = new StringBuilder();
            foreach (var s in _teStack)
            {
                sb.Append(s);
            }
            Assert.AreEqual(sb.ToString(),"caitianshiwo");
            Assert.AreEqual(_teStack.Count(), 4);
        }
    }
}
