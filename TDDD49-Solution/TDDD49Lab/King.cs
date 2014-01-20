using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class King : Piece
    {
        private static readonly int KING_MOVE_REACH = 1;
        private static readonly List<Point> KING_DC = new List<Point>()
        {
            new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1), new Point(1, 1), new Point(-1, 1), new Point(-1, -1), new Point (1, -1)
        };

        private bool firstMove;

        public King(Point position, Side side, string texturePath)
            : base(position, PieceType.King, side, texturePath, KING_DC, KING_MOVE_REACH)
        {
            firstMove = true;
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
