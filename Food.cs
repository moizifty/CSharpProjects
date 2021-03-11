using System;

namespace SnakeGame
{
    class Food : IDrawable
    {
        public Point Position {get; set;}
        private char _displayChar = 'o'; 
        public Food(Point pos) => Position = pos;

        public void UpdateDrawable()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_displayChar);
        }

        public void Consume()
        {
            Position = LevelManager.GetRandomPoint();
        }
    }
}
