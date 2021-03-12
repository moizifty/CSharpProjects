using System;

namespace SnakeGame
{
    class Program
    {
        public static readonly Point padding = new Point(3, 3);
        static void Main(string[] args)
        {
            Point p = GetConsoleDimensions();
            Rect levelBounds = new Rect(padding, p.X, p.Y);
            Point levelCenter = (levelBounds.TopLeft + new Point(levelBounds.Width, levelBounds.Height)) * 0.5f;

            LevelManager.GenerateLevel(levelBounds);
            Snake snake = new Snake(levelCenter, 3);
            LevelManager.DrawLevelBoundary();

            //Console.CursorVisible = false;
            while(true)
            {
                foreach(Food f in LevelManager.FoodList)
                {
                    if(f.ReadyToUpdate)
                    {
                        f.UpdateDrawable();
                        f.ReadyToUpdate = false;
                    }
                }
                snake.UpdateDrawable();
                System.Threading.Thread.Sleep(80);
            }
        }

        static Point GetConsoleDimensions() => new Point(Console.BufferWidth, Console.WindowHeight) - (padding * 2);
    }
}
