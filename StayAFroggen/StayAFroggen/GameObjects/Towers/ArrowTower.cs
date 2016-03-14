namespace StayAFroggen.GameObjects.Towers
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Projectiles;
    using TextureLoading;
    using Timer;
    using Units;

    public class ArrowTower : Tower
    {
        private const int ArrowTowerTextureWidth = 100;
        private const int ArrowTowerTextureHeight = 180;

        private const int ArrowTowerDamage = 20;
        private const int ArrowTowerRange = 3;
        private const float ArrowTowerAttackTimeInSeconds = 0.5f;

        private const int ArrowTowerDestRectWidth = 70; // 100 * 0.7
        private const int ArrowTowerDestRectHeight = 126; // 180 * 0.7

        public ArrowTower(Vector2 position) : base()
        {
            this.X = position.X;
            this.Y = position.Y;

            this.SpriteSheet = TextureLoader.ArrowTowerSprite;
            this.TextureWidth = ArrowTowerTextureWidth;
            this.TextureHeight = ArrowTowerTextureHeight;

            this.Range = ArrowTowerRange;
            //this.SightArea = new Circle((int)this.X + (ArrowTowerDestRectWidth / 2), (int)this.Y + ArrowTowerDestRectHeight - 20, (int)(this.Range * 80));
            this.SightArea = new Rectangle(
                (int)this.X + (ArrowTowerDestRectWidth / 2) - (int)(this.Range * 80) / 2,
                (int)this.Y + ArrowTowerDestRectHeight - 35 - (int)(this.Range * 80) / 2,
                (int)(this.Range * 80),
                (int)(this.Range * 80));

            this.Damage = ArrowTowerDamage;
            this.AttackTimer = new Timer();
            this.AttackTimeInSeconds = ArrowTowerAttackTimeInSeconds;
        }

        private bool PrincessInRange { get; set; }

        private Rectangle SightArea { get; }

        public override void Attack(IPrincess unit)
        {
            IProjectile proj = new ArrowTowerProjectile(new Vector2(this.X + ArrowTowerDestRectWidth / 2, this.Y + 10), unit, this.Damage);
            Engine.Projectiles.Add(proj);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.AttackTimer.CheckIfReady(gameTime))
            {
                PrincessInRange = false;
                foreach (IUnit unit in Engine.Units)
                {
                    if (!(unit is IPrincess))
                    {
                        continue;
                    }

                    if (!unit.IsActive)
                    {
                        continue;
                    }

                    IPrincess princess = (IPrincess)unit;
                    if (this.SightArea.Intersects(princess.WalkingBox))
                    {
                        PrincessInRange = true;
                        this.Attack(princess);
                        this.AttackTimer.SetTimer(gameTime, this.AttackTimeInSeconds);
                        break;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.SpriteSheet,
                 new Rectangle((int)this.X, (int)this.Y, ArrowTowerDestRectWidth, ArrowTowerDestRectHeight),
                Color.White);

            Color color = PrincessInRange ? Color.Red : Color.Green;
            spriteBatch.Draw(TextureLoader.TheOnePixel, new Rectangle((int)this.X - 25, (int)this.Y + 60, 25, 25), color);

            //spriteBatch.Draw(
            //    TextureLoader.TheOnePixel,
            //    new Rectangle(
            //        (int)this.X + (ArrowTowerDestRectWidth / 2) - (int)(this.Range * 80) / 2,
            //        (int)this.Y + ArrowTowerDestRectHeight - 35 - (int)(this.Range * 80) / 2,
            //        (int)(this.Range * 80),
            //        (int)(this.Range * 80)),
            //    color);
        }
    }
}
