using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Labyrint
{
    internal class Figur
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Ellipse e { get; }
        public Figur(int row, int col)
        {
            e = new Ellipse();
            e.Fill = Brushes.Blue;
            e.Width = 10;
            e.Height = 10;
            Canvas.SetLeft(e, col * 10); 
            Canvas.SetTop(e, row * 10);

            Row = row;
            Col = col;
        }
        // Versucht, die Figur um (dRow,dCol) zu bewegen.
        // canMove entscheidet, ob das Ziel betreten werden darf.
        public bool TryMove(int dRow, int dCol, Func<int, int, bool> canMove)
        {
            int newRow = Row + dRow;
            int newCol = Col + dCol;
            if (canMove(newRow, newCol))
            {
                Row = newRow;
                Col = newCol;
                return true;
            }

            return false;
        }
    }
}

