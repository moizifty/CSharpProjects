using System;

namespace SnakeGame
{
    class Food : IDrawable
    {
        public Point Position {get; set;}
        public bool IsStatic {get; set;} = true;
        public bool ReadyToUpdate {get; set;} = true;

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
            ReadyToUpdate = true;
        }
    }
}
