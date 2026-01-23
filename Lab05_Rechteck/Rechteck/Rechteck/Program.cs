using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechteck
{
    using System;
    
    using System.Collections.Generic;

    class RectangleObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; }
        public int Height { get; }

        public RectangleObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Draw()
        {
            // Position nach unten verschieben
            for (int i = 0; i < Y; i++)
                Console.WriteLine();

            // Rechteck zeichnen
            for (int i = 0; i < Height; i++)
            {
                Console.Write(new string(' ', X));
                Console.WriteLine(new string('#', Width));
            }
        }
    }

    class Canvas
    {
        private readonly List<RectangleObject> rectangles = new List<RectangleObject>();

        public void Add(RectangleObject rect)
        {
            rectangles.Add(rect);
        }

        public RectangleObject GetLast()
        {
            if (rectangles.Count == 0)
                return null;

            return rectangles[rectangles.Count - 1];
        }

        public void Render()
        {
            Console.Clear();
            foreach (var rect in rectangles)
                rect.Draw();
        }
    }

    class Program
    {
        static void Main()
        {
            Canvas canvas = new Canvas();

            Console.Write("Wie viele Rechtecke sollen gezeichnet werden? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nRechteck {i + 1}:");

                Console.Write("Breite: ");
                int width = int.Parse(Console.ReadLine());

                Console.Write("Höhe: ");
                int height = int.Parse(Console.ReadLine());

                Console.Write("Position X: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Position Y: ");
                int y = int.Parse(Console.ReadLine());

                var rect = new RectangleObject(x, y, width, height);
                canvas.Add(rect);
                canvas.Render();
            }

            Console.WriteLine("\nBewege das letzte Rechteck mit WASD oder Pfeiltasten.");
            Console.WriteLine("Beenden mit ESC.");

            var lastRect = canvas.GetLast();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    break;

                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        lastRect.Move(0, -1);
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        lastRect.Move(0, 1);
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        lastRect.Move(-1, 0);
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        lastRect.Move(1, 0);
                        break;
                }

                canvas.Render();
            }
        }
    }
}
