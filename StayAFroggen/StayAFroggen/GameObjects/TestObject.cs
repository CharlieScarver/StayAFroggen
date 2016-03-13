namespace StayAFroggen.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;

    public class TestObject : GameObject
    {
        public TestObject(Vector2 position) : base()
        {
            this.X = position.X;
            this.Y = position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.TheOnePixel, this.Position, new Rectangle((int)this.X, (int)this.Y, 50, 50), Color.AliceBlue);
        }
    }
}
