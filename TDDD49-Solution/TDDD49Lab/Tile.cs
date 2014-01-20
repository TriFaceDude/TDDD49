using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.ComponentModel;


namespace TDDD49Lab
{
    public class Tile : INotifyPropertyChanged
    {
        Piece piece;
        SolidColorBrush background;
        SolidColorBrush highlight;

        bool check;

        public SolidColorBrush Background
        {
            get { return background; }
            set { background = value; }
        }


        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                InvokePropertyChanged("Piece");
            }
        }

        public SolidColorBrush Highlight
        {
            get { return highlight; }
            set
            {
                highlight = value;
                InvokePropertyChanged("Highlight");
            }
        }

        /// <summary>
        /// Tile constructor
        /// </summary>
        /// <param name="background">Defines the background color of the tile</param>
        public Tile(SolidColorBrush background)
        {
            Background = background;
        }

        /// <summary>
        /// Checks if a the tile contains a piece
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            return Piece == null;
        }

        /// <summary>
        /// Cheks if the tile contains a piece of a specified side
        /// </summary>
        /// <param name="side">Side to check for</param>
        /// <returns>bool</returns>
        public bool IsOccupiedBy(Side side)
        {
            if (IsEmpty())
                return false;

            return Piece.Side == side;
        }

        /// <summary>
        /// Checks if the tile contains a piece of a specified type
        /// </summary>
        /// <param name="type">Type to check for</param>
        /// <returns>bool</returns>
        public bool OccupiedBy(PieceType type)
        {
            if (IsEmpty())
                return false;

            return Piece.Type == type;
        }

        /// <summary>
        /// Call when a property is changed, used to update UI
        /// </summary>
        /// <param name="propertyName">Name of the property updated</param>
        private void InvokePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
