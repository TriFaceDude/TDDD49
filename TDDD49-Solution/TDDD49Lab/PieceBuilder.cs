using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDD49Lab
{
    public static class PieceBuilder
    {
        // Textures for all dark pieces
        private static readonly string D_KING_TEXTURE = @"Content\Images\D_King.png";
        private static readonly string D_QUEEN_TEXTURE = @"Content\Images\D_Queen.png";
        private static readonly string D_ROOK_TEXTURE = @"Content\Images\D_Rook.png";
        private static readonly string D_BISHOP_TEXTURE = @"Content\Images\D_Bishop.png";
        private static readonly string D_KNIGHT_TEXTURE = @"Content\Images\D_Knight.png";
        private static readonly string D_PAWN_TEXTURE = @"Content\Images\D_Pawn.png";

        // Textures for all light pieces
        private static readonly string L_KING_TEXTURE = @"Content\Images\L_King.png";
        private static readonly string L_QUEEN_TEXTURE = @"Content\Images\L_Queen.png";
        private static readonly string L_ROOK_TEXTURE = @"Content\Images\L_Rook.png";
        private static readonly string L_BISHOP_TEXTURE = @"Content\Images\L_Bishop.png";
        private static readonly string L_KNIGHT_TEXTURE = @"Content\Images\L_Knight.png";
        private static readonly string L_PAWN_TEXTURE = @"Content\Images\L_Pawn.png";


        /// <summary>
        /// Puts a standard set of pieces on the board
        /// </summary>
        /// <param name="board">Game board</param>
        public static void InitPieces(Board board)
        {
            List<Tile> tiles = new List<Tile>();

            for (int i = 0; i < board.Width; i++)
            {
                board.AddPiece(MakePawn(new Point(i, 1), Side.Dark), new Point(i, 1));
            }
            for (int i = 0; i < board.Width; i++)
            {
                board.AddPiece(MakePawn(new Point(i, 6), Side.Light), new Point(i, 6));
            }

            //Kings
            board.AddPiece(MakeKing(new Point(4, 0), Side.Dark), new Point(4, 0));
            board.AddPiece(MakeKing(new Point(4, 7), Side.Light), new Point(4, 7));

            //Queens
            board.AddPiece(MakeQueen(new Point(3, 0), Side.Dark), new Point(3, 0));
            board.AddPiece(MakeQueen(new Point(3, 7), Side.Light), new Point(3, 7));

            //Bishops
            board.AddPiece(MakeBishop(new Point(2, 0), Side.Dark), new Point(2, 0));
            board.AddPiece(MakeBishop(new Point(5, 0), Side.Dark), new Point(5, 0));

            board.AddPiece(MakeBishop(new Point(2, 7), Side.Light), new Point(2, 7));
            board.AddPiece(MakeBishop(new Point(5, 7), Side.Light), new Point(5, 7));

            //Knights
            board.AddPiece(MakeKnight(new Point(1, 0), Side.Dark), new Point(1, 0));
            board.AddPiece(MakeKnight(new Point(6, 0), Side.Dark), new Point(6, 0));

            board.AddPiece(MakeKnight(new Point(1, 7), Side.Light), new Point(1, 7));
            board.AddPiece(MakeKnight(new Point(6, 7), Side.Light), new Point(6, 7));

            //Rook
            board.AddPiece(MakeRook(new Point(0, 0), Side.Dark), new Point(0, 0));
            board.AddPiece(MakeRook(new Point(7, 0), Side.Dark), new Point(7, 0));

            board.AddPiece(MakeRook(new Point(0, 7), Side.Light), new Point(0, 7));
            board.AddPiece(MakeRook(new Point(7, 7), Side.Light), new Point(7, 7));

            board.UpdatePieces();
        }

        /// <summary>
        /// Returns a piece of the type King
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakeKing(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_KING_TEXTURE;
            else
                texturePath = L_KING_TEXTURE;

            return new King(position, side, texturePath);
        }


        /// <summary>
        /// Returns a piece of the type Queen
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakeQueen(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_QUEEN_TEXTURE;
            else
                texturePath = L_QUEEN_TEXTURE;

            return new Queen(position, side, texturePath);
        }

        /// <summary>
        /// Returns a piece of the type Rook
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakeRook(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_ROOK_TEXTURE;
            else
                texturePath = L_ROOK_TEXTURE;

            return new Rook(position, side, texturePath);
        }

        /// <summary>
        /// Returns a piece of the type Bishop
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakeBishop(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_BISHOP_TEXTURE;
            else
                texturePath = L_BISHOP_TEXTURE;

            return new Bishop(position, side, texturePath);
        }

        /// <summary>
        /// Returns a piece of the type Knight
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakeKnight(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_KNIGHT_TEXTURE;
            else
                texturePath = L_KNIGHT_TEXTURE;

            return new Knight(position, side, texturePath);
        }

        /// <summary>
        /// Returns a piece of the type Pawn
        /// </summary>
        /// <param name="position">Position of the piece</param>
        /// <param name="side">Side of the piece</param>
        /// <returns>Piece</returns>
        public static Piece MakePawn(Point position, Side side)
        {
            string texturePath;

            if (side == Side.Dark)
                texturePath = D_PAWN_TEXTURE;
            else
                texturePath = L_PAWN_TEXTURE;

            return new Pawn(position, side, texturePath);
        }
    }
}
