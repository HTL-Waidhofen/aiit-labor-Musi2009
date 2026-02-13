using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO; 
namespace Example
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("maze_6x6.txt"); 
            string inhalt = reader.ReadToEnd();
            string[] zeilen = inhalt.Split('\n');
            int anzahlZeilen = zeilen.Length;

            this.Spielfeld.Background = Brushes.Black;
            for(int i = 0; i<10; i++)
            {
                for(int j = 0; j < anzahlZeilen; j++)
                {
                    if (zeilen[i][j] == '#')
                    {
                        Rectangle r = new Rectangle();
                        r.Fill = Brushes.White;
                        r.Width = 10;
                        r.Height = 10;
                        Canvas.SetLeft(r, j * 10);
                        Canvas.SetTop(r, i * 10);
                        this.Spielfeld.Children.Add(r);
                    }
                }
            }
        }
    }
}
