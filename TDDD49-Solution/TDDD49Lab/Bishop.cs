using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Bishop : Piece
    {
        private static readonly int BISHOP_MOVE_REACH = 7;
        private static readonly List<Point> BISHOP_DC = new List<Point>()
        {
            new Point(1, 1), new Point(-1, 1), new Point(-1, -1), new Point (1, -1)
        };

        public Bishop(Point position, Side side, string texturePath)
            : base(position, PieceType.Bishop, side, texturePath, BISHOP_DC, BISHOP_MOVE_REACH)
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
