using TDDD49Lab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTest
{


    /// <summary>
    ///This is a test class for BoardTest and is intended
    ///to contain all BoardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BoardTest
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
        ///A test for CoordinateToIndex
        ///</summary>
        [TestMethod()]
        public void CoordinateToIndexTest_00()
        {
            Board target = new Board();
            Point point = new Point(0, 0);
            int expected = 0; // (0,0) should be the 1st (Index: 0) element in the list (using default board width/height of 8)
            int actual;
            actual = target.CoordinateToIndex(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CoordinateToIndex
        ///</summary>
        [TestMethod()]
        public void CoordinateToIndexTest_12()
        {
            Board target = new Board();
            Point point = new Point(1, 2);
            int expected = 17; // (1,2) should be the 18th (Index: 17) element in the list (using default board width/height of 8)
            int actual;
            actual = target.CoordinateToIndex(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CoordinateToIndex
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CoordinateToIndexTest_87()
        {
            Board target = new Board();
            Point point = new Point(8, 7);  // (8,7) should be the 65th (Index: 64) which is outside list range therefore an exception is expected (using default board width/height of 8)
            int actual;
            actual = target.CoordinateToIndex(point);
        }

        /// <summary>
        ///A test for GetPiece
        ///</summary>
        [TestMethod()]
        public void GetPieceTest_null()
        {
            Board target = new Board();
            Piece piece = PieceBuilder.MakePawn(new Point(1, 1), Side.Light);   //Adds no piece
            Point position = new Point(1, 1);   // Look for piece at (1,1)
            Piece expected = null;
            Piece actual;
            actual = target.GetPiece(position);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetPiece
        ///</summary>
        [TestMethod()]
        public void GetPieceTest_notNull()
        {
            Board target = new Board();
            Piece piece = PieceBuilder.MakePawn(new Point(1, 1), Side.Light);
            target.AddPiece(piece, new Point(1, 1));   // Adds a piece at (1,1) all other tiles will be null
            Point position = new Point(1, 1);   // Look for piece at (1,1)
            Piece expected = piece;
            Piece actual;
            actual = target.GetPiece(position);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTile
        ///</summary>
        [TestMethod()]
        public void GetTileTest_notNull()
        {
            Board target = new Board();
            Point position = new Point(0, 0); // We know from CoordinateToIndexTest_00 that (0,0) is equivalent to index: 0
            Tile expected = target.Tiles[0]; // The result should be the first tile in the list of tiles
            Tile actual;
            actual = target.GetTile(position);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTile
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetTileTest_Null()
        {
            Board target = new Board();
            Point position = new Point(8, 7);   // We know from CoordinateToIndexTest_87 that (8,7) is equivalent to index: 64
            Tile actual;    // which should give us an IndexOutOfRange error
            actual = target.GetTile(position);

        }

        /// <summary>
        ///A test for InBounds
        ///</summary>
        [TestMethod()]
        public void InBoundsTest_11()
        {
            Board target = new Board();
            Point point = new Point(1, 1);   // The point (1,1) is in range
            bool expected = true;   //True is expected
            bool actual;
            actual = target.InBounds(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InBounds
        ///</summary>
        [TestMethod()]
        public void InBoundsTest_81()
        {
            Board target = new Board();
            Point point = new Point(8, 1);   // The x coordinant is out of range
            bool expected = false;   //False is expected
            bool actual;
            actual = target.InBounds(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InBounds
        ///</summary>
        [TestMethod()]
        public void InBoundsTest_18()
        {
            Board target = new Board();
            Point point = new Point(1, 8);   // The y coordinant is out of range
            bool expected = false;   //False is expected
            bool actual;
            actual = target.InBounds(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InBounds
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void InBoundsTest_Null()
        {
            Board target = new Board();
            Point point = null; // NullReferenceException is expected
            bool actual;
            actual = target.InBounds(point);
        }

        /// <summary>
        ///A test for IndexToCoordinate
        ///</summary>
        [TestMethod()]
        public void IndexToCoordinateTest_0()
        {
            Board target = new Board();
            int index = 0;
            Point expected = new Point(0, 0); // Index 0 gives the point (0,0) 
            Point actual;   //Point (0,0) is expected
            actual = target.IndexToCoordinate(index);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IndexToCoordinate
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexToCoordinateTest_65()
        {
            Board target = new Board();
            int index = 65;
            Point actual;   //IndexOutOfRangeException is expected
            actual = target.IndexToCoordinate(index);
        }

        /// <summary>
        ///A test for IndexToCoordinate
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexToCoordinateTest_neg1()
        {
            Board target = new Board();
            int index = -1;
            Point actual;   //IndexOutOfRangeException is expected
            actual = target.IndexToCoordinate(index);
        }

        /// <summary>
        ///A test for TryMovePiece
        ///</summary>
        [TestMethod()]
        public void TryMovePieceTest_12()
        {
            Board board = new Board();
            Piece piece = PieceBuilder.MakeKing(new Point(1, 1), Side.Light);
            board.AddPiece(piece, new Point(1, 1));
            piece.UpdateValidMoveList(board);
            Point target = new Point(1, 2); //Move the king one step down
            bool expected = true;
            bool actual;
            actual = board.TryMovePiece(piece, target);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for TryMovePiece
        ///</summary>
        [TestMethod()]
        public void TryMovePieceTest_11()
        {
            Board board = new Board();
            Piece piece = PieceBuilder.MakeKing(new Point(1, 1), Side.Light);
            board.AddPiece(piece, new Point(1, 1));
            piece.UpdateValidMoveList(board);
            Point target = new Point(1, 1); //Move the king to the same position
            bool expected = false;
            bool actual;
            actual = board.TryMovePiece(piece, target);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TryMovePiece
        ///</summary>
        [TestMethod()]
        public void TryMovePieceTest_13()
        {
            Board board = new Board();
            Piece piece = PieceBuilder.MakeKing(new Point(1, 1), Side.Light);
            board.AddPiece(piece, new Point(1, 1));
            piece.UpdateValidMoveList(board);
            Point target = new Point(1, 3); //Move the king two steps down
            bool expected = false;
            bool actual;
            actual = board.TryMovePiece(piece, target);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TryMovePiece
        ///</summary>
        [TestMethod()]
        public void TryMovePieceTest_88()
        {
            Board board = new Board();
            Piece piece = PieceBuilder.MakeKing(new Point(1, 1), Side.Light);
            board.AddPiece(piece, new Point(1, 1));
            piece.UpdateValidMoveList(board);
            Point target = new Point(8, 8); //Move the king outside the board
            bool expected = false;
            bool actual;
            actual = board.TryMovePiece(piece, target);
            Assert.AreEqual(expected, actual);
        }
    }
}
