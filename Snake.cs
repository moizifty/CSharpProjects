using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake : IDrawable
    {
        private static bool _firstDrawCall;
        private Point _previousDirection = new Point(0, 0);
        private Point _direction = new Point(1, 0);
        private List<Point> tailPoints;
        private char topLeftChar = '╔';
        private char topRightChar = '╗';
        private char bottomLeftChar = '╚';
        private char bottomRightChar = '╝';
        private char horiChar = '═';
        private char vertChar = '║';

        public Point Position {get; set;} = Point.zero;
        public int Length {get; set;} = 0;

        public Snake() {tailPoints = new List<Point>();}

        public Snake(Point pos, int length = 0) => (Position, Length, tailPoints) = (pos, length, new List<Point>(length));

        public void UpdateDrawable() 
        {
            MoveSnake();
            var (foodCollided, foodCollidedWith) = CheckFoodCollision();
            if(foodCollided)
            {
                Length++;
                foodCollidedWith.Consume();
            }
            ClearTrailingTail();
        }
        private void MoveSnake()
        {
            tailPoints.Add(Position);
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                _previousDirection = _direction;
                _direction = key.Key switch 
                {
                    ConsoleKey.W => new Point(0, -1),
                    ConsoleKey.A => new Point(-1, 0),
                    ConsoleKey.S => new Point(0, 1),
                    ConsoleKey.D => new Point(1, 0),
                    _ => _direction,
                };
                if((_previousDirection.Y == -_direction.Y) || (_previousDirection.X == -_direction.X))
                    _direction = _previousDirection;

                while(Console.KeyAvailable)
                { 
                    Console.ReadKey(true);
                }
                Console.SetCursorPosition(Position.X, Position.Y);
                DrawChar(CalculateCornerChar());
            }
            Position += _direction;
            int levelWidth = LevelManager.LevelBounds.TopLeft.X + LevelManager.LevelBounds.Width;
            int levelHeight = LevelManager.LevelBounds.TopLeft.Y + LevelManager.LevelBounds.Height;

            if(Position.X >= levelWidth - 1)
                Position = new Point(LevelManager.LevelBounds.TopLeft.X + 1, Position.Y);
            else if(Position.X <= LevelManager.LevelBounds.TopLeft.X)
                Position = new Point(levelWidth - 2, Position.Y);

            if(Position.Y >= levelHeight - 1)
                Position = new Point(Position.X, LevelManager.LevelBounds.TopLeft.Y + 1);
            else if(Position.Y <= LevelManager.LevelBounds.TopLeft.Y)
                Position = new Point(Position.X, levelHeight - 2);

            Console.SetCursorPosition(Position.X, Position.Y);
            DrawChar(CalculateNormalChar());
        }
        private void DrawChar(char ch)
        {
            Console.Write(ch);
        }
        private void ClearTrailingTail()
        {
            for(int i = 0; i < tailPoints.Count - Length; i++)
            {
                Console.SetCursorPosition(tailPoints[i].X, tailPoints[i].Y);
                Console.Write(" ");

                tailPoints.RemoveAt(i);
            }
        }
        private char CalculateCornerChar()
        {
            if(_previousDirection == _direction)
                return CalculateNormalChar();
                
            if(_direction.Y == -1)
            {
                if(_previousDirection.X == -1)
                    return bottomLeftChar;
                else
                    return bottomRightChar;
            }
            else if(_direction.Y == 1)
            {
                if(_previousDirection.X == -1)
                    return topLeftChar;
                else
                    return topRightChar;
            }
            else if(_direction.X == 1)
            {
                if(_previousDirection.Y == -1)
                    return topLeftChar;
                else
                    return bottomLeftChar;
            }
            else if(_direction.X == -1)
            {
                if(_previousDirection.Y == -1)
                    return topRightChar;
                else
                    return bottomRightChar;
            }
            return CalculateNormalChar();
                
        }
        private char CalculateNormalChar()
        {
            if(_direction.Y != 0)
                return vertChar;
            else
                return horiChar;
        }
        private (bool, Food?) CheckFoodCollision()
        {
            foreach(Food f in LevelManager.FoodList)
            {
                if(f.Position == Position)
                    return (true, f);
            }
            return (false, null);
        }
    }
}
