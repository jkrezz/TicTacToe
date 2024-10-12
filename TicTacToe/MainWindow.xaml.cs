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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isXTurn = true;
        private int?[] _board = new int?[9];
        private Rectangle?[] _cells;

        public MainWindow()
        {
            InitializeComponent();
            _cells = new Rectangle[] { Cell0, Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8 };
        }

        // Рестарт игры
        private void ResetGame()
        {
            _isXTurn = true;
            _board = new int?[9];
            Game.Children.Clear();

            Game.Children.Add(new Line { X1 = 106, Y1 = 0, X2 = 106, Y2 = 320, Stroke = Brushes.Black, StrokeThickness = 4 });
            Game.Children.Add(new Line { X1 = 220, Y1 = 0, X2 = 220, Y2 = 320, Stroke = Brushes.Black, StrokeThickness = 4 });
            Game.Children.Add(new Line { X1 = 0, Y1 = 101, X2 = 339, Y2 = 101, Stroke = Brushes.Black, StrokeThickness = 4 });
            Game.Children.Add(new Line { X1 = 0, Y1 = 219, X2 = 339, Y2 = 219, Stroke = Brushes.Black, StrokeThickness = 4 });

            foreach (Rectangle cell in _cells)
            {
                Game.Children.Add(cell);
            }
        }

    }
}