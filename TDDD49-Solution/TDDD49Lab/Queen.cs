using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Queen : Piece
    {
        private static readonly int QUEEN_MOVE_REACH = 7;
        private static readonly List<Point> QUEEN_DV = new List<Point>()
        {
            new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1), new Point(1, 1), new Point(-1, 1), new Point(-1, -1), new Point (1, -1)
        };

        public Queen(Point position, Side side, string texturePath)
            : base(position, PieceType.Queen, side, texturePath, QUEEN_DV, QUEEN_MOVE_REACH)
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
