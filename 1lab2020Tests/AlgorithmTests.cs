using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1lab2020;

namespace _1lab2020.Tests
{
    [TestClass()]
    public class AlgorithmTests
    {
        [TestMethod()]
        public void FindMaxIndexAllElemPosTest()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 0 };
            int expected = 3;

            int actual = Algorithm.FindMaxIndex(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindMaxIndexWithNegElemTest()
        {
            int[] arr = new int[] { 10, -3, 3, 4, -6 };
            int expected = 0;

            int actual = Algorithm.FindMaxIndex(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindMaxIndexWithSameElemTest()
        {
            int[] arr = new int[5] { 10, -3, 3, 10, -6 };
            int expected = 3;

            int actual = Algorithm.FindMaxIndex(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindMaxIndexWithAllNegElemTest()
        {
            int[] arr = new int[5] { -10, -3, -13, -10, -6 };
            int expected = 1;

            int actual = Algorithm.FindMaxIndex(arr);

            Assert.AreEqual(expected, actual);
        }

    }
}