using System;
using System.Collections.Generic;
namespace SnakeGame
{
    static class LevelManager
    {
        public const int MAX_FOOD_AMOUNT = 10;
        public static List<Food> FoodList {get; private set;}
        public static Rect LevelBounds {get; private set;}

        public static void GenerateLevel(Rect levelBounds)
        {
            LevelBounds = levelBounds;
            FoodList = new List<Food>(MAX_FOOD_AMOUNT);
            for(int i = 0; i < MAX_FOOD_AMOUNT; i++)
            {
                FoodList.Add(GenerateFood());
            }
        }
        public static void DrawLevelBoundary()
        {
            Console.Clear();
            Console.SetCursorPosition(LevelBounds.TopLeft.X, LevelBounds.TopLeft.Y);

            for(int x = 0; x < LevelBounds.Width; x++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for(int y = 1; y < LevelBounds.Height - 1; y++)
            {
                Console.SetCursorPosition(LevelBounds.TopLeft.X, LevelBounds.TopLeft.Y + y);
                Console.Write("|");
                
                Console.CursorLeft = Console.BufferWidth - 1 - LevelBounds.TopLeft.X;
                Console.Write("|");
            }
            Console.WriteLine();
            Console.CursorLeft = LevelBounds.TopLeft.X;
            for(int x = 0; x < LevelBounds.Width; x++)
            {
                Console.Write("*");
            }
        }
        public static Point GetRandomPoint()
        {
            Random random = new Random();
            int posX = random.Next(LevelBounds.TopLeft.X + 1, (LevelBounds.TopLeft.X + LevelBounds.Width) - 2);
            int posY = random.Next(LevelBounds.TopLeft.Y + 1, (LevelBounds.TopLeft.Y + LevelBounds.Height) - 2);

            return new Point(posX, posY);
        }
        private static Food GenerateFood()
        {
            return new Food(GetRandomPoint());
        }
    }
}
