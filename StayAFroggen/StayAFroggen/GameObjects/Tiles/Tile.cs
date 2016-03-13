namespace StayAFroggen.GameObjects.Tiles
{
    using Enumerations;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;

    public class Tile : GameObject, ITile
    {
        private const int TileTextureSize = 80;

        public Tile(Vector2 position, TileType type) : base()
        {
            this.X = position.X;
            this.Y = position.Y;
            this.Type = type;

            if (this.Type == TileType.Grass)
            {
                this.SpriteSheet = TextureLoader.GrassTile;
            }
            else if (this.Type == TileType.Road)
            {
                this.SpriteSheet = TextureLoader.RoadTile;
            }

            this.BoundingBox = new Rectangle(
                (int)this.X,
                (int)this.Y,
                TileTextureSize,
                TileTextureSize
                );
        }

        public TileType Type { get; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.Type == TileType.Grass)
            {
                spriteBatch.Draw(TextureLoader.GrassTile, this.Position, Color.White);
            }
            else if (this.Type == TileType.Road)
            {
                spriteBatch.Draw(TextureLoader.RoadTile, this.Position, Color.White);
            }
        }
    }
}
