using TDDD49Lab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media;


namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for TileTest and is intended
    ///to contain all TileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TileTest
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
        ///A test for IsEmpty
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest_null()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255));     //Background is irrelevant
            Tile target = new Tile(background);
            target.Piece = null;                // There is now no piece present on the tile
            bool expected = true;              // "True" is therefore expected
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest_notNull()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255));   //Background is irrelevant
            Tile target = new Tile(background);
            target.Piece = PieceBuilder.MakeBishop(new Point(0, 0), Side.Light);              // There is now a piece present on the tile
            bool expected = false;                                                            // "False" is therefore expected
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsOccupiedBy
        ///</summary>
        [TestMethod()]
        public void IsOccupiedByTest_side_null()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background);
            Side side = Side.Light; // Ask if the tile is occupied by a light piece
            target.Piece = null;    // Piece is null (no piece present)
            bool expected = false; // "False" is therefore expected
            bool actual;
            actual = target.IsOccupiedBy(side);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsOccupiedBy
        ///</summary>
        [TestMethod()]
        public void IsOccupiedByTest_side_light()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background);
            Side side = Side.Light; // Ask if the tile is occupied by a light piece
            target.Piece = PieceBuilder.MakeBishop(new Point(0, 0), Side.Light); ;    // Piece of side (team) light is present
            bool expected = true; // "True" is therefore expected
            bool actual;
            actual = target.IsOccupiedBy(side);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsOccupiedBy
        ///</summary>
        [TestMethod()]
        public void IsOccupiedByTest_side_dark()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background);
            Side side = Side.Light; // Ask if the tile is occupied by a light piece
            target.Piece = PieceBuilder.MakeBishop(new Point(0, 0), Side.Dark); ;    // Piece of side (team) dark is present
            bool expected = false; // "False" is therefore expected
            bool actual;
            actual = target.IsOccupiedBy(side);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OccupiedBy
        ///</summary>
        [TestMethod()]
        public void OccupiedByTest_type_null()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background); 
            PieceType type = PieceType.Pawn; // Ask if the tile is occupied by a piece of type pawn
            target.Piece = null; // No piece is present
            bool expected = false; // "False" is therefore expected
            bool actual;
            actual = target.OccupiedBy(type);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OccupiedBy
        ///</summary>
        [TestMethod()]
        public void OccupiedByTest_type_pawn()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background);
            PieceType type = PieceType.Pawn; // Ask if the tile is occupied by a piece of type pawn
            target.Piece = PieceBuilder.MakePawn(new Point(0,0), Side.Light); // Pawn present
            bool expected = true; // "True" is therefore expected
            bool actual;
            actual = target.OccupiedBy(type);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OccupiedBy
        ///</summary>
        [TestMethod()]
        public void OccupiedByTest_type_king()
        {
            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //Background is irrelevant
            Tile target = new Tile(background);
            PieceType type = PieceType.Pawn; // Ask if the tile is occupied by a piece of type pawn
            target.Piece = PieceBuilder.MakeKing(new Point(0, 0), Side.Light); // No piece is present
            bool expected = false; // "False" is therefore expected
            bool actual;
            actual = target.OccupiedBy(type);
            Assert.AreEqual(expected, actual);
        }
    }
}
