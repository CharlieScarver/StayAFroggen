namespace StayAFroggen.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ICollideable
    {
        Rectangle BoundingBox { get; }

        int BoundingBoxX { get; }

        int BoundingBoxY { get; }

        void DrawBb(SpriteBatch spriteBatch, Color boundingBoxColor);

    }
}
