namespace StayAFroggen.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IGameObject : ICollideable, IDrawable
    {
        int Id { get; }

        bool IsActive { get; }

        Vector2 Position { get; }

        float X { get; }

        float Y { get; }

        void Nullify();
    }
}
