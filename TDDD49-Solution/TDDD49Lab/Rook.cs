using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Rook : Piece
    {
        private static readonly int ROOK_MOVE_REACH = 7;
        private static readonly List<Point> ROOK_DV = new List<Point>()
        {
            new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1)
        };

        private bool firstMove;

        public Rook(Point position, Side side, string texturePath)
            : base(position, PieceType.Rook, side, texturePath, ROOK_DV, ROOK_MOVE_REACH)
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

            foreach (Point position in possibleMoves)
            {
                if (!board.InBounds(position))
                    possibleMoves.Remove(position);

            }

            this.ValidMoves = possibleMoves;
        }
    }
}