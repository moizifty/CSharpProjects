using System;

namespace SnakeGame
{
    struct Point
    {
        public static readonly Point zero = new Point(0, 0);

        public int X {get; set;}
        public int Y {get; set;}

        public Point(int x, int y) => (X, Y) = (x, y);
        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        
        public static Point operator *(Point p1, int s) => new Point(p1.X * s, p1.Y * s);
        public static Point operator *(Point p1, float s) => new Point((int)Math.Ceiling(p1.X * s), (int)Math.Ceiling(p1.Y * s));
        
        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);
        public static Point operator -(Point p1) => new Point(-p1.X, -p1.Y);

        public static bool operator ==(Point p1, Point p2) => (p1.X == p2.X) && (p1.Y == p2.Y);
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2);

        public override bool Equals(object? obj)
        {
            if(obj == null || this.GetType() != obj.GetType())
                return false;
            else
                return (obj as Point?) == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
