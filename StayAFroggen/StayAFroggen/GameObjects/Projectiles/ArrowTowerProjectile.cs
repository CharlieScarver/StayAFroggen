namespace StayAFroggen.GameObjects.Projectiles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;

    public class ArrowTowerProjectile : Projectile
    {
        private const int ArrowTowerProjTextureWidth = 62;
        private const int ArrowTowerProjTextureHeight = 12;
        private const int ArrowTowerProjDestRectWidth = 31;
        private const int ArrowTowerProjDestRectHeight = 6;

        public ArrowTowerProjectile(Vector2 position, Point targetPoint, int damage) : base()
        {
            this.X = position.X;
            this.Y = position.Y;

            this.SpriteSheet = TextureLoader.ArrowTowerProjectile;
            this.TextureWidth = ArrowTowerProjTextureWidth;
            this.TextureHeight = ArrowTowerProjTextureHeight;

            this.Damage = damage;
            this.TargetPoint = targetPoint;
        }

        private int Damage { get; }
        private Point TargetPoint { get; }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.SpriteSheet,
                 new Rectangle((int)this.X, (int)this.Y, ArrowTowerProjDestRectWidth, ArrowTowerProjDestRectHeight),
                Color.White);
        }
    }
}
