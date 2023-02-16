using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_ReturnsVal()
        {
            Node<int> node = new(42);
            Assert.AreEqual(42, node.Val);
        }

        [TestMethod]
        public void Node_OverridesToString_Pass()
        {
            Node<int> node = new(42);
            Assert.AreEqual("42", node.Val.ToString());
        }

        [TestMethod]
        public void Node_AppendThrowsExceptionIfValExists()
        {
            Node<int> node = testHelper();
            Assert.ThrowsException<ArgumentException>(() => node.Append(44));
        }

        [TestMethod]
        public void Node_NextPropertyReferenceNextNode()
        {
            Node<int> node = new(42);
            node.Append(43);

            Assert.AreEqual<int>(43, node.Next.Val);
        }

        [TestMethod]
        public void Node_AppendInsertsAfterOriginalNode()
        {
            Node<int> node = testHelper();
            Assert.AreEqual<int>(45, node.Next.Val);
        }

        [TestMethod]
        public void Node_MaintainsCircularLinkWithFourNodes()
        {
            Node<int> node = testHelper();
            Assert.AreEqual<int>(42, node.Next.Next.Next.Next.Val);
        }

        [TestMethod]
        public void Node_NextPropertyReferencesSelf()
        {
            Node<int> node = new(42);
            Assert.AreEqual<int>(42, node.Next.Val);
        }

        [TestMethod]
        public void Node_GarbageCollection()
        {
            Node<int> node = testHelper();
            WeakReference nodeRef = GarbageCollectionTestHelper(node);
            node.Clear();

            GC.Collect();
            bool isAlive = nodeRef.IsAlive;

            Assert.IsFalse(isAlive);
        }

        [TestMethod]
        public void Node_GenericsConstructorThrowsErrorIfPassedNull()
        {
            Action action = () => new Node<string>(null!);
            Assert.ThrowsException<ArgumentNullException>(() => action.Invoke());
        }

        [TestMethod]
        public void Node_ClearTest()
        {
            Node<int> node = testHelper();
            node.Clear();
            Assert.AreEqual(node.Next, node);
        }

        public Node<int> testHelper()
        {
            Node<int> node = new(42);
            node.Append(43);
            node.Append(44);
            node.Append(45);
            return node;
        }

        public WeakReference GarbageCollectionTestHelper(Node<int> node)
        {
            WeakReference nodeRef = new(node.Next);
            return nodeRef;
        }
    }
}