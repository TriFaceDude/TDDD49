using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public class Pawn : Piece, INotifyOnMove
    {
        private static readonly int PAWN_MOVE_REACH = 1;

        private List<Point> D_PAWN_DC = new List<Point>()
        {
           new Point(0, 1), new Point(1, 1), new Point(-1, 1), new Point(0, 2)
        };

        private List<Point> L_PAWN_DC = new List<Point>()
        {
           new Point(0, -1), new Point(1, -1), new Point(-1, -1), new Point(0, -2)
        };

        private bool firstMove;

        public Pawn(Point position, Side side, string texturePath)
            : base(position, PieceType.Pawn, side, texturePath, null, PAWN_MOVE_REACH)
        {
            if (side == Side.Dark)
                DirectionCoefficients = D_PAWN_DC;
            else
                DirectionCoefficients = L_PAWN_DC;


            firstMove = true;
        }


        /// <summary>
        /// Updates the ValidMoves property of this piece
        /// </summary>
        /// <param name="board">Game board</param>
        public override void UpdateValidMoveList(Board board)
        {

            List<Point> possibleMoves = GetMoveList(board);
            List<Point> forbiddenMoves = new List<Point>();


            foreach (Point position in possibleMoves)   // Adds movement rules specific for pawns
            {
                if (this.Position.X == position.X)
                {
                    if (!board.GetTile(position).IsEmpty())
                        forbiddenMoves.Add(position);
                }
                else
                {
                    if (board.GetTile(position).IsEmpty())
                        forbiddenMoves.Add(position);
                }
            }

            foreach (Point position in forbiddenMoves)
                possibleMoves.Remove(position);

            this.ValidMoves = possibleMoves;
        }

        public void OnMove()
        {
            if (firstMove)
            {
                firstMove = false;
                DirectionCoefficients.RemoveAt(DirectionCoefficients.Count - 1);
            }
        }
    }
}
