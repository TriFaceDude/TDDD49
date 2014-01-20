using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace TDDD49Lab
{
    public partial class MainWindow : Window
    {
        ChessComponent chessComponent;

        public MainWindow()
        {
            InitializeComponent();

            chessComponent = new ChessComponent();
            this.DataContext = chessComponent;
        }


        private void PieceTexture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(this);
            chessComponent.BeginDrag((Image)sender, new Point((int)mousePosition.X, (int)mousePosition.Y));
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(this);
            chessComponent.EndDrag((Grid)sender, new Point((int)mousePosition.X, (int)mousePosition.Y), e.Data);
        }
    }
}
