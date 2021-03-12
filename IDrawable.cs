namespace SnakeGame
{
    interface IDrawable
    {
        bool IsStatic {get; set;}
        bool ReadyToUpdate {get; set;} //only if static
        void UpdateDrawable();
    }
}
