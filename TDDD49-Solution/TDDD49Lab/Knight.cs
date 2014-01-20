using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Knight : Piece
    {
        private static readonly int KNIGHT_MOVE_REACH = 1;
        private static readonly List<Point> KNIGHT_DC = new List<Point>()
        {
            new Point(2, 1), new Point(2, -1), new Point(-2, 1), new Point(-2, -1), new Point(1, 2), new Point(-1, 2), new Point(1, -2), new Point (-1, -2)
        };

        public Knight(Point position, Side side, string texturePath)
            : base(position, PieceType.Knight, side, texturePath, KNIGHT_DC, KNIGHT_MOVE_REACH)
        {
        }

        /// <summary>
        /// Updates the ValidMoves property of this piece
        /// </summary>
        /// <param name="board">Game board</param>
        public override void UpdateValidMoveList(Board board)
        {
            List<Point> possibleMoves = GetMoveList(board);


            this.ValidMoves = possibleMoves;
        }
    }
}
