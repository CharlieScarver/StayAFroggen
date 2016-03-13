namespace StayAFroggen.GameObjects.Units
{
    using System;
    using System.Net.Configuration;
    using Core;
    using Input;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;
    using Timer;
    using Towers;

    public class Builder : Unit, IBuilder
    {
        private const float BuilderDefaultMovementSpeed = 7;

        public Builder(Vector2 position) : base()
        {
            this.X = position.X;
            this.Y = position.Y;

            this.MovementSpeed = BuilderDefaultMovementSpeed;

            this.UnableToBuildTimer = new Timer();
        }

        private Timer UnableToBuildTimer { get; }
        public bool TowerToBuild { get; set; }

        private void ManageMovement()
        {
            if (this.IsMovingUp)
            {
                this.Y -= this.MovementSpeed;
            }
            else if (this.IsMovingDown)
            {
                this.Y += this.MovementSpeed;
            }

            if (this.IsMovingRight)
            {
                this.X += this.MovementSpeed;
            }
            else if (this.IsMovingLeft)
            {
                this.X -= this.MovementSpeed;
            }
        }

        public void BuildTower(GameTime gameTime)
        {
            // for perfect position on the block
            Vector2 position = new Vector2((float)(Math.Floor(this.X / 80) * 80 + 5), (float)(Math.Floor(this.Y / 80) * 80 + 80 - 5 - 126));
            ITower tower = new ArrowTower(position);
            Engine.Towers.Add(tower);
            this.UnableToBuildTimer.SetTimer(gameTime, 3.0);
        }

        public override void Update(GameTime gameTime)
        {
            InputHandler.HandleInput(gameTime, this);

            if (this.TowerToBuild && this.UnableToBuildTimer.CheckIfReady(gameTime))
            {
                this.BuildTower(gameTime);
            }
            else
            {
                this.TowerToBuild = false;
            }

            this.ManageMovement();

        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.TheOnePixel, this.Position, new Rectangle((int)this.X, (int)this.Y, 25, 25), Color.DarkCyan);
        }
    }
}
