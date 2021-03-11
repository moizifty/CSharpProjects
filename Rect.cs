using System;

namespace SnakeGame
{
    struct Rect 
    {
        public Point TopLeft {get; set;}
        public int Width {get; set;}
        public int Height {get; set;}

        public Rect(Point topLeft, int width = 0, int height = 0) 
                    => (TopLeft, Width, Height) = (topLeft, width, height);
    }
}
