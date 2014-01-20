using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TDDD49Lab
{
    public class Board
    {
        private const int DEFAULT_WIDTH = 8;
        private const int DEFAULT_HEIGHT = 8;

        ObservableCollection<Tile> tiles;
        List<Piece> pieces;

        int width;
        int height;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public ObservableCollection<Tile> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Board()
            : this(DEFAULT_WIDTH, DEFAULT_HEIGHT)
        {
        }


        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            tiles = new ObservableCollection<Tile>();
            pieces = new List<Piece>();

            CreateTiles(width, height);
        }

        /// <summary>
        /// Fills the board with a standard chess-setup of peices
        /// </summary>
        public void Init()
        {
            PieceBuilder.InitPieces(this);
        }

        /// <summary>
        /// Generates a standard chessboard
        /// </summary>
        /// <param name="width">Number of tiles wide</param>
        /// <param name="height">Number of tiles high</param>
        private void CreateTiles(int width, int height)
        {
            SolidColorBrush dark = new SolidColorBrush(Color.FromRgb(95, 75, 55));
            SolidColorBrush light = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    SolidColorBrush color;

                    if (y % 2 == 0 && x % 2 == 0 || y % 2 == 1 && x % 2 == 1)
                        color = dark;
                    else
                        color = light;

                    tiles.Add(new Tile(color));
                }
            }
        }

        /// <summary>
        /// Adds a piece on the board, will replace whatever piece is already present
        /// </summary>
        /// <param name="piece">The piece to add</param>
        /// <param name="position">The position a att the piece to</param>
        public void AddPiece(Piece piece, Point position)
        {
            Tiles[CoordinateToIndex(position)].Piece = piece;
            pieces.Add(piece);
        }

        /// <summary>
        /// Updates the ValidMoves property for all pieces on the board
        /// </summary>
        public void UpdatePieces()
        {
            foreach (Piece piece in pieces)
                piece.UpdateValidMoveList(this);
        }

        /// <summary>
        /// Will move the piece to a position if the position exists in the ValidMoves list property of the piece, it will also notify pieces that has implemented the INotifyOnMove interface
        /// </summary>
        /// <param name="piece">The piece to be moved</param>
        /// <param name="target">The position to move to</param>
        /// <returns>bool, is moved allowed?</returns>
        public bool TryMovePiece(Piece piece, Point target)
        {
            if (piece.Position == target)
                return false;

            if (piece is INotifyOnMove)
            {
                INotifyOnMove inom = (INotifyOnMove)piece;
                inom.OnMove();
            }

            List<Point> validMoves = piece.ValidMoves;

            if (validMoves.Contains(target))
            {
                MovePiece(piece, target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Moves a piece to another tile, the piece will replace whatever piece already present
        /// </summary>
        /// <param name="piece">The piece to be moved</param>
        /// <param name="target">The position to move to</param>
        private void MovePiece(Piece piece, Point target)
        {
            Tiles[CoordinateToIndex(target)].Piece = piece;
            Tiles[CoordinateToIndex(piece.Position)].Piece = null;
            piece.Position = target;
        }

        /// <summary>
        /// Converts a position to a list index, throws IndexOutOfRangeException if position is outside board
        /// </summary>
        /// <param name="point">The position to convert</param>
        /// <returns>int</returns>
        public int CoordinateToIndex(Point point)
        {
            if (!InBounds(point))
                throw new IndexOutOfRangeException("Point is outside board.");

            return point.X + point.Y * Width;
        }

        /// <summary>
        /// Converts list index to a Point position, throws IndexOutOfRangeException if index is out of range
        /// </summary>
        /// <param name="index">A list index</param>
        /// <returns>Point</returns>
        public Point IndexToCoordinate(int index)
        {
            if (index < 0 || index > tiles.Count - 1)
                throw new IndexOutOfRangeException();

            return new Point(index % width, (int)(index / width));
        }

        /// <summary>
        /// Checks if a position is within the bounds of the board
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool InBounds(Point point)
        {
            if (point.X > width - 1 || point.X < 0)
                return false;

            if (point.Y > height - 1 || point.Y < 0)
                return false;

            return true;
        }

        /// <summary>
        /// Gets tiles for each position in the point list, throws IndexOutOfRangeException if position is outside board
        /// </summary>
        /// <param name="pointList">A list of positions</param>
        /// <returns>List of Tiles</returns>
        public List<Tile> ToTileList(List<Point> pointList)
        {
            List<Tile> tileList = new List<Tile>();

            foreach (Point point in pointList)
                tileList.Add(GetTile(point));

            return tileList;
        }

        /// <summary>
        /// Returns the tile located at the position, throws IndexOutOfRangeException if position is outside board
        /// </summary>
        /// <param name="position">The tile position</param>
        /// <returns>Tile</returns>
        public Tile GetTile(Point position)
        {
            return Tiles[CoordinateToIndex(position)];
        }

        /// <summary>
        /// Returns the piece located at the position, returns null if no piece is present
        /// </summary>
        /// <param name="position">The tile position</param>
        /// <returns>Piece</returns>
        public Piece GetPiece(Point position)
        {
            return Tiles[CoordinateToIndex(position)].Piece;
        }

        /// <summary>
        /// Highlights possible moves for the piece
        /// </summary>
        /// <param name="piece">The active piece</param>
        public void HighlightMoves(Piece piece)
        {
            List<Tile> moveList = new List<Tile>();

            moveList = ToTileList(piece.ValidMoves);

            foreach (Tile tile in moveList)
            {
                if (tile.IsEmpty())
                    tile.Highlight = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                else if (tile.IsOccupiedBy(Piece.InverseSide(piece.Side)))
                    tile.Highlight = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        /// <summary>
        /// Sets hihglight property to null for all tiles on the board
        /// </summary>
        public void RemoveHighlighs()
        {
            foreach (Tile tile in tiles)
                tile.Highlight = null;
        }
    }
}
