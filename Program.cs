using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp();
            Turtle.Speed = 4; //начальная скорость черепашки

            GraphicsWindow.BrushColor = "Red";
            var eat = Shapes.AddRectangle(10, 10);

            int x = 200;
            int y = 200;
            Shapes.Move( eat, x, y);

            Random rand = new Random();

            while (true)//движение черепахи
            {
                Turtle.Move(10);
                if ((Turtle.X >= x && Turtle.X <= x+10 ) && (Turtle.Y >= y && Turtle.Y <= y+10))//перемещение еды при достижении черепашкой точки
                {
                    x = rand.Next(0, GraphicsWindow.Width-30);
                    y = rand.Next(0, GraphicsWindow.Height-30);
                    Shapes.Move(eat, x, y);
                    Turtle.Speed = Turtle.Speed + 0.7;
                }

                //отскок от экрана
                if (Turtle.X == 0 || Turtle.X >= GraphicsWindow.Width - 10 || Turtle.Y == 0 || Turtle.Y >= GraphicsWindow.Height - 10)
                {
                    Turtle.Angle -= 180;
                }
            }
            

        }

        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            else if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            else if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            else if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}
