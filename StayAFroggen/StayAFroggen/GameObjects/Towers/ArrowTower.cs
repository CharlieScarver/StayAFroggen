namespace StayAFroggen.GameObjects.Towers
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;

    public class ArrowTower : Tower
    {
        private const int ArrowTowerTextureWidth = 100;
        private const int ArrowTowerTextureHeight = 180;

        private const int ArrowTowerDamage = 20;
        private const int ArrowTowerRange = 3;

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
        }

        private bool PrincessInRange { get; set; }
        private Rectangle SightArea { get; }

        public override void Update(GameTime gameTime)
        {
            PrincessInRange = false;
            foreach (IUnit unit in Engine.Units)
            {
                if (!(unit is IPrincess))
                {
                    continue;
                }
                IPrincess princess = (IPrincess) unit;
                if (this.SightArea.Intersects(princess.WalkingBox))
                {
                    PrincessInRange = true;
                    break;
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
