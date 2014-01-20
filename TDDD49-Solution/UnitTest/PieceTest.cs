using TDDD49Lab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for PieceTest and is intended
    ///to contain all PieceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PieceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        /// <summary>
        ///A test for InverseSide
        ///</summary>
        [TestMethod()]
        public void InverseSideTest_DtL()
        {
            Side side = Side.Light;
            Side expected = Side.Dark;
            Side actual;
            actual = Piece.InverseSide(side);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InverseSide
        ///</summary>
        [TestMethod()]
        public void InverseSideTest_LtD()
        {
            Side side = Side.Dark;
            Side expected = Side.Light;
            Side actual;
            actual = Piece.InverseSide(side);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidMoves
        ///</summary>
        [TestMethod()]
        public void ValidMovesTest_true00()
        {
            Piece target = PieceBuilder.MakeKnight(new Point(0,0), Side.Dark);
            Board board = new Board();
            target.UpdateValidMoveList(board);

            List<Point> expected = new List<Point>() { new Point(1, 2), new Point(2, 1) };
            List<Point> actual;
            actual = target.ValidMoves;

            bool result = true;

            foreach (Point point in expected)
            {
                if (!actual.Contains(point))
                {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        ///A test for ValidMoves
        ///</summary>
        [TestMethod()]
        public void ValidMovesTest_true22()
        {
            Piece target = PieceBuilder.MakeKnight(new Point(2, 2), Side.Dark);
            Board board = new Board();
            target.UpdateValidMoveList(board);

            List<Point> expected = new List<Point>() { new Point(1, 0), new Point(0, 1), new Point(3, 0), new Point(0, 3), new Point(1, 4), new Point(4, 1), new Point(3, 4), new Point(4, 3) };
            List<Point> actual;
            actual = target.ValidMoves;

            bool result = true;

            foreach (Point point in expected)
            {
                if (!actual.Contains(point))
                {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        ///A test for ValidMoves
        ///</summary>
        [TestMethod()]
        public void ValidMovesTest_false00()
        {
            Piece target = PieceBuilder.MakeKnight(new Point(0, 0), Side.Dark);
            Board board = new Board();
            target.UpdateValidMoveList(board);

            List<Point> expected = new List<Point>() { new Point(3, 2), new Point(2, 1) };
            List<Point> actual;
            actual = target.ValidMoves;

            bool result = true;

            foreach (Point point in expected)
            {
                if (!actual.Contains(point))
                {
                    result = false;
                    break;
                }
            }

            Assert.IsFalse(result);
        }
    }
}
