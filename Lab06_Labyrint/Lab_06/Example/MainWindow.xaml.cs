using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Labyrint
{
    public partial class MainWindow : Window
    {
        private Figur figur;
        private char[,] maze;
        private const int CellSize = 10;

        public MainWindow()
        {
            InitializeComponent();

            // Datei einlesen
            string[] zeilen = File.ReadAllLines("maze_20x20.txt")
                                  .Select(l => l.TrimEnd('\r')).ToArray();
            int rows = zeilen.Length;
            int cols = rows > 0 ? zeilen[0].Length : 0;
            maze = new char[rows, cols];

            this.Spielfeld.Background = Brushes.White;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char c = zeilen[i][j];
                    maze[i, j] = c;

                    if (c == '#')
                    {
                        var r = new Rectangle
                        {
                            Fill = Brushes.Black,
                            Width = CellSize,
                            Height = CellSize
                        };
                        Canvas.SetLeft(r, j * CellSize);
                        Canvas.SetTop(r, i * CellSize);
                        this.Spielfeld.Children.Add(r);
                    }
                    else if (c == 'X')
                    {
                        figur = new Figur(i, j);
                        Canvas.SetLeft(figur.e, j * CellSize);
                        Canvas.SetTop(figur.e, i * CellSize);
                        this.Spielfeld.Children.Add(figur.e);
                    }
                }
            }

            // Tasten-Events registrieren und Fokus setzen, damit das Fenster Tasten empfängt
            this.KeyDown += MainWindow_KeyDown;
            this.Loaded += (s, e) => this.Focus();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (figur == null) return;

            // e.Key enthält den gedrückten Key — das gehört in das switch(...)
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    if (figur.TryMove(-1, 0, CanMove))
                        UpdateFigurPosition();
                    break;
                case Key.S:
                case Key.Down:
                    if (figur.TryMove(1, 0, CanMove))
                        UpdateFigurPosition();
                    break;
                case Key.A:
                case Key.Left:
                    if (figur.TryMove(0, -1, CanMove))
                        UpdateFigurPosition();
                    break;
                case Key.D:
                case Key.Right:
                    if (figur.TryMove(0, 1, CanMove))
                        UpdateFigurPosition();
                    break;
            }
        }

        private void UpdateFigurPosition()
        {
            // Figur.Row/Col stammen aus deiner Figur-Klasse
            Canvas.SetLeft(figur.e, figur.Col * CellSize);
            Canvas.SetTop(figur.e, figur.Row * CellSize);
        }

        private bool CanMove(int row, int col)
        {
            if (maze == null) return false;
            if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1)) return false;
            return maze[row, col] != '#';
        }
    }
}