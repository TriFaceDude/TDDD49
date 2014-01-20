using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace TDDD49Lab
{
    public enum PieceType
    {
        FirstMoveKing, King, Queen, FirstMoveRook, Rook, Bishop, Knight, FirstMovePawn, Pawn
    }

    public enum Side
    {
        Light, Dark
    }

    public abstract class Piece
    {
        private Point position;
        private List<Point> directionVector;
        private int moveReach;

        private bool check;

        private PieceType type;
        private Side side;
        private BitmapImage texture;

        private List<Point> validMoves;

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public List<Point> DirectionCoefficients
        {
            get { return directionVector; }
            set { directionVector = value; }
        }

        public PieceType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Side Side
        {
            get { return side; }
            set { side = value; }
        }

        public BitmapImage Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public List<Point> ValidMoves
        {
            get { return validMoves; }
            set { validMoves = value; }
        }

        /// <summary>
        /// Piece constructor
        /// </summary>
        /// <param name="position">The position on the game board</param>
        /// <param name="type">The type piece</param>
        /// <param name="side">The side (team)</param>
        /// <param name="texturePath">A relative path to an image file</param>
        /// <param name="directionVector">A list of vectors defining the movement pattern of the piece</param>
        /// <param name="moveReach">How many steps the piece can move</param>
        public Piece(Point position, PieceType type, Side side, string texturePath, List<Point> directionVector, int moveReach)
        {
            this.position = position;
            this.type = type;
            this.side = side;
            LoadTexture(texturePath);
            this.directionVector = directionVector;
            this.moveReach = moveReach;
        }

        /// <summary>
        /// Loads a BitmapImage from file
        /// </summary>
        /// <param name="path">A relative path to the file</param>
        public void LoadTexture(string path)
        {
            this.texture = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        public abstract void UpdateValidMoveList(Board board);

        /// <summary>
        /// Returns a list of possible moves based on the piece direction vector and movement range
        /// </summary>
        /// <param name="board">Game board</param>
        /// <returns>List of Points</returns>
        protected List<Point> GetMoveList(Board board)
        {
            List<Point> moves = new List<Point>();

            foreach (Point direction in directionVector)
            {
                for (int i = 1; i <= moveReach; i++)
                {
                    Point point = new Point(this.position.X + direction.X * i, this.position.Y + direction.Y * i);


                    if (board.InBounds(point))
                    {
                        if (!ForbiddenCollision(point, board))
                            moves.Add(point);

                        if (!board.GetTile(point).IsEmpty())
                            break;
                    }
                }
            }

            return moves;
        }

        /// <summary>
        /// Checks for collision with pieces of piece-type King and pieces of the same side
        /// </summary>
        /// <param name="position">Point position of tile</param>
        /// <param name="board">Game board</param>
        /// <returns>bool</returns>
        private bool ForbiddenCollision(Point position, Board board)
        {
            return board.GetTile(position).OccupiedBy(PieceType.King) || board.GetTile(position).IsOccupiedBy(this.Side);
        }

        /// <summary>
        /// Returns the inverse of input parameter
        /// </summary>
        /// <param name="side">The side you want the inverse of</param>
        /// <returns>Side</returns>
        public static Side InverseSide(Side side)
        {
            if (side == Side.Dark)
                return Side.Light;
            else
                return Side.Dark;
        }
    }
}
