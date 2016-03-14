namespace StayAFroggen.GameObjects.Projectiles
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Structures;
    using TextureLoading;

    public class ArrowTowerProjectile : Projectile
    {
        private const int ArrowTowerProjTextureWidth = 62;
        private const int ArrowTowerProjTextureHeight = 12;
        private const int ArrowTowerProjDestRectWidth = 31;
        private const int ArrowTowerProjDestRectHeight = 6;

        private const int ArrowTowerProjDefaultTicksToHit = 30;

        public ArrowTowerProjectile(Vector2 position, IPrincess target, int damage) : base()
        {
            this.X = position.X;
            this.Y = position.Y;

            this.SpriteSheet = TextureLoader.ArrowTowerProjectile;
            this.TextureWidth = ArrowTowerProjTextureWidth;
            this.TextureHeight = ArrowTowerProjTextureHeight;

            this.BoundingBox = new Rectangle((int)this.X, (int)this.Y, this.TextureWidth, this.TextureHeight);

            this.Damage = damage;
            this.TicksToHit = 30;
            this.Target = target;

            this.IsMovingLeft = false;
        }

        private int TicksToHit { get; set; }

        private bool IsMovingLeft { get; set; }

        private void UpdateBoundingBox()
        {
            this.BoundingBoxX = (int) this.X;
            this.BoundingBoxY = (int) this.Y;
        }

        public override void Update(GameTime gameTime)
        {
            if (Collision.CheckForCollisionBetweenCollidables(this, this.Target))
            {
                this.IsActive = false;
                this.Target.GetHit(this.Damage);
            }

            if (this.IsActive)
            {
                Point hitPoint = new Point
                (this.Target.BoundingBox.X + this.Target.BoundingBox.Width / 2,
                    this.Target.BoundingBox.Y + this.Target.BoundingBox.Height / 2);

                bool moveUp = false || this.Position.Y > hitPoint.Y;
                bool moveLeft = false || this.Position.X > hitPoint.X;
                this.IsMovingLeft = moveLeft;

                this.Velocity = new VelocityXY(
                    (int)(moveLeft ? (this.Position.X - hitPoint.X) / this.TicksToHit : (hitPoint.X - this.Position.X) / this.TicksToHit),
                    (int)(moveUp ? (this.Position.Y - hitPoint.Y) / this.TicksToHit : (hitPoint.Y - this.Position.Y) / this.TicksToHit));

                this.TicksToHit -= 2;
                if (this.TicksToHit < 0)
                {
                    this.TicksToHit = ArrowTowerProjDefaultTicksToHit;
                }

                if (moveUp) { this.Y -= this.Velocity.velocityY; }
                else { this.Y += this.Velocity.velocityY; }

                if (moveLeft) { this.X -= this.Velocity.velocityX; }
                else { this.X += this.Velocity.velocityX; }

                this.UpdateBoundingBox();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsMovingLeft)
            {
                spriteBatch.Draw(
                    this.SpriteSheet,
                        new Rectangle((int)this.X, (int)this.Y, ArrowTowerProjDestRectWidth, ArrowTowerProjDestRectHeight),
                    Color.White);
            }
            else
            {
                spriteBatch.Draw(
                     texture: this.SpriteSheet,
                     destinationRectangle: new Rectangle((int)this.X, (int)this.Y, ArrowTowerProjDestRectWidth, ArrowTowerProjDestRectHeight),
                     color: Color.White,
                     effects: SpriteEffects.FlipHorizontally);
            }
        }
    }
}
