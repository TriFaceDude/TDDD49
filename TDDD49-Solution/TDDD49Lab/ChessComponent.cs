using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TDDD49Lab
{
    class ChessComponent
    {
        private Board board;
        private Side turn;

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }

        public ChessComponent()
        {
            board = new Board();
            board.Init();
            turn = Side.Light;
        }

        /// <summary>
        /// Begins a drag event for a piece, converts the piece to DataObject for use in EndDrag
        /// </summary>
        /// <param name="image">UI element that is interacted with</param>
        /// <param name="mousePosition">Position of mouse in pixels relative to top left</param>
        public void BeginDrag(Image image, Point mousePosition)
        {
            Grid grid = (Grid)image.Parent;

            double tileWidth = grid.RenderSize.Width;
            double tileHeight = grid.RenderSize.Height;

            Point tilePosition = new Point((int)(mousePosition.X / tileWidth), (int)(mousePosition.Y / tileHeight));
            Tile tile = board.GetTile(tilePosition);

            if (turn == tile.Piece.Side)
            {
                board.HighlightMoves(tile.Piece);
                DataObject dataObject = new DataObject(typeof(Piece), tile.Piece);
                DragDrop.DoDragDrop(image, dataObject, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Ends the drag event
        /// </summary>
        /// <param name="grid">The UI element the piece is dropped in</param>
        /// <param name="mousePosition">Mouse position in pixels relative to top left</param>
        /// <param name="data">DataObject from BeginDrag</param>
        public void EndDrag(Grid grid, Point mousePosition, IDataObject data)
        {

            double tileWidth = grid.RenderSize.Width;
            double tileHeight = grid.RenderSize.Height;

            Point tilePosition = new Point((int)(mousePosition.X / tileWidth), (int)(mousePosition.Y / tileHeight));

            Piece piece = (Piece)data.GetData(typeof(Piece));

            if (board.TryMovePiece(piece, tilePosition))
            {
                board.UpdatePieces();
                turn = Piece.InverseSide(turn);
            }

            board.RemoveHighlighs();
        }
    }
}
