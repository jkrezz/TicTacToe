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

        private void Cell_MouseClick(object sender, MouseButtonEventArgs e)
        {
            Rectangle? cell = sender as Rectangle;
            int index = int.Parse(cell.Name.Replace("Cell", ""));

            if (_board[index] == null)
            {
                _board[index] = _isXTurn ? 1 : 2;
                DrawSymbol(cell, _board[index]);
                _isXTurn = !_isXTurn;

                if (CheckForWin())
                {
                    MessageBox.Show($"P{_board[index]} win!");
                    ResetGame();
                }
                else if (CheckForDraw())
                {
                    MessageBox.Show("Draw!");
                    ResetGame();
                }
            }
        }
        private void DrawSymbol(Rectangle cell, int? symbol)
        {
            double left = Canvas.GetLeft(cell);
            double top = Canvas.GetTop(cell);

            if (symbol == 1)
            {
                Line line1 = new Line
                {
                    X1 = left + 10,
                    Y1 = top + 10,
                    X2 = left + 90,
                    Y2 = top + 90,
                    Stroke = Brushes.Red,
                    StrokeThickness = 4
                };

                Line line2 = new Line
                {
                    X1 = left + 90,
                    Y1 = top + 10,
                    X2 = left + 10,
                    Y2 = top + 90,
                    Stroke = Brushes.Red,
                    StrokeThickness = 4
                };

                Game.Children.Add(line1);
                Game.Children.Add(line2);
            }
            else
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 80,
                    Height = 80,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 4,
                    Margin = new Thickness(left + 10, top + 10, 0, 0)
                };
                Game.Children.Add(ellipse);
            }

        }

        private bool CheckForWin()
        {
            int[,] winPatterns = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }
            };

            for (int i = 0; i < 8; i++)
            {
                if (_board[winPatterns[i, 0]] != null &&
                    _board[winPatterns[i, 0]] == _board[winPatterns[i, 1]] &&
                    _board[winPatterns[i, 1]] == _board[winPatterns[i, 2]])
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckForDraw()
        {
            foreach (int? cell in _board)
            {
                if (cell == null) return false;
            }
            return true;
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