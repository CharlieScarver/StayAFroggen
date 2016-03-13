namespace StayAFroggen.GameObjects.Units
{
    using System;
    using Core;
    using Enumerations;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TextureLoading;

    public class Princess : Unit, IPrincess
    {
        private const int PrincessTextureWidth = 140;
        private const int PrincessTextureHeight = 140;
        private const int PrincessBasicAnimationDelay = 200;
        private const int PrincessBasicAnimationFrameCount = 2;
        private const int PrincessDefaultHealth = 100;
        private const float PrincessDefaultMovementSpeed = 2.5f;

        private const int PrincessBoundingBoxWidth = 30;
        private const int PrincessBoundingBoxHeight = 30;
        private const int PrincessDestRectSize = 80;

        private Rectangle walkingBox;

        public Princess(Vector2 position) : base()
        {
            this.X = position.X;
            this.Y = position.Y;

            this.SpriteSheet = TextureLoader.PrincessSheet;
            this.TextureWidth = PrincessTextureWidth;
            this.TextureHeight = PrincessTextureHeight;

            this.WalkingBox = new Rectangle(
                (int)this.X,
                (int)this.Y,
                PrincessDestRectSize,
                PrincessDestRectSize);

            this.BoundingBox = new Rectangle(
                (int)this.X + ((this.TextureWidth / 2) - (PrincessBoundingBoxWidth / 2)),
                (int)this.Y + ((this.TextureHeight / 2) - (PrincessBoundingBoxHeight / 2)),
                PrincessBoundingBoxWidth,
                PrincessBoundingBoxHeight);

            this.CurrentFrame = 0;
            this.BasicAnimationFrameCount = PrincessBasicAnimationFrameCount;
            this.Timer = 0;
            this.Delay = PrincessBasicAnimationDelay;
            this.SourceRect = new Rectangle();

            this.Health = PrincessDefaultHealth;
            this.MovementSpeed = PrincessDefaultMovementSpeed;

            this.IsMovingRight = true;
        }
        
        public Rectangle WalkingBox
        {
            get
            {
                return this.walkingBox;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Bounding box shouldn't be null");
                }

                this.walkingBox = value;
            }
        }
        public int WalkingBoxX
        {
            get { return this.walkingBox.X; }
            set { this.walkingBox.X = value; }
        }
        public int WalkingBoxY
        {
            get { return this.walkingBox.Y; }
            set { this.walkingBox.Y = value; }
        }

        private Rectangle FutureBox { get; set; }
        private Direction LastDirection { get; set; }

        // IDestroyable
        public int Health { get; }
        
        // IAnimateable
        public int CurrentFrame { get; private set; }
        public int BasicAnimationFrameCount { get; }
        public double Timer { get; private set; }
        public int Delay { get; }
        public Rectangle SourceRect { get; private set; }

        private void BasicAnimationLogic(GameTime gameTime, int delay, int basicAnimationFrameCount)
        {
            this.Timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer >= delay)
            {
                this.CurrentFrame++;

                if (this.CurrentFrame >= basicAnimationFrameCount)
                {
                    this.CurrentFrame = 0;
                }

                this.Timer = 0.0;
            }
        }

        private void ManageAnimation(GameTime gameTime)
        {
            if (this.IsMovingUp)
            {
                this.AnimateMovement(gameTime, 1);
            }
            else if (this.IsMovingDown)
            {
                this.AnimateMovement(gameTime, 0);
            }
            else if (this.IsMovingRight)
            {
                this.AnimateMovement(gameTime, 2);
            }
            else if (this.IsMovingLeft)
            {
                this.AnimateMovement(gameTime, 3);
            }
        }

        private void ManageMovement()
        {
            if (this.IsMovingUp)
            {
                this.Y -= this.MovementSpeed;
                this.FutureBox = new Rectangle(
                    (int)this.X,
                    (int)(this.Y - this.MovementSpeed),
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);
                LastDirection = Direction.Up;
            }
            else if (this.IsMovingDown)
            {
                this.Y += this.MovementSpeed;
                this.FutureBox = new Rectangle(
                    (int)this.X,
                    (int)(this.Y + this.MovementSpeed),
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);
                LastDirection = Direction.Down;
            }
            else if (this.IsMovingRight)
            {
                this.X += this.MovementSpeed;
                this.FutureBox = new Rectangle(
                    (int)(this.X + this.MovementSpeed),
                    (int)this.Y,
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);
                LastDirection = Direction.Right;
            }
            else if (this.IsMovingLeft)
            {
                this.X -= this.MovementSpeed;
                this.FutureBox = new Rectangle(
                    (int)(this.X - this.MovementSpeed),
                    (int)this.Y,
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);
                LastDirection = Direction.Left;
            }
        }

        private void UpdateBoundingBox()
        {
            this.BoundingBoxX = (int)this.X + ((PrincessDestRectSize / 2) - (PrincessBoundingBoxWidth / 2));
            this.BoundingBoxY = (int)this.Y + ((PrincessDestRectSize / 2) - (PrincessBoundingBoxHeight / 2));

            this.WalkingBoxX = (int) this.X;
            this.WalkingBoxY = (int) this.Y;
        }

        private void AnimateMovement(GameTime gameTime, int spriteSheetRowIndex)
        {
            this.BasicAnimationLogic(gameTime, PrincessBasicAnimationDelay, PrincessBasicAnimationFrameCount);
            this.SourceRect = new Rectangle(
                this.CurrentFrame * PrincessTextureHeight, 
                PrincessTextureHeight * spriteSheetRowIndex,
                PrincessTextureHeight, 
                PrincessTextureHeight);
        }

        private Direction NextDirection()
        {
            Direction newDirection = Direction.Right;

            if (this.IsMovingUp && this.LastDirection != Direction.Right)
            {
                this.IsMovingUp = false;
                this.IsMovingRight = true;

                this.FutureBox = new Rectangle(
                    (int)(this.X + this.MovementSpeed),
                    (int)this.Y,
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);

                newDirection = Direction.Right;
            }
            else if (this.IsMovingRight && this.LastDirection != Direction.Down)
            {
                this.IsMovingRight = false;
                this.IsMovingDown = true;

                this.FutureBox = new Rectangle(
                    (int)this.X,
                    (int)(this.Y + this.MovementSpeed),
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);

                newDirection = Direction.Down;
            }
            else if (this.IsMovingDown && this.LastDirection != Direction.Left)
            {
                this.IsMovingDown = false;
                this.IsMovingLeft = true;

                this.FutureBox = new Rectangle(
                    (int)(this.X - this.MovementSpeed),
                    (int)this.Y,
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);

                newDirection = Direction.Left;
            }
            else if (this.IsMovingLeft && this.LastDirection != Direction.Up)
            {
                this.IsMovingLeft = false;
                this.IsMovingUp = true;

                this.FutureBox = new Rectangle(
                    (int)this.X,
                    (int)(this.Y - this.MovementSpeed),
                    this.WalkingBox.Width,
                    this.WalkingBox.Height);

                newDirection = Direction.Up;
            }

            return newDirection;
        }

        private void FindPath()
        {
            // dummy value
            Direction comingFrom = this.LastDirection + 2;
            if (comingFrom > Direction.Left)
            {
                comingFrom -= 4;
            }
            Direction newDirection = Direction.Left + 1;

            for (int directionsChecked = 1; 
                (Collision.CheckForCollisionWithGrassTiles(FutureBox) 
                && directionsChecked <= 4)
                || newDirection == comingFrom;
                directionsChecked++)
            {
                newDirection = NextDirection();
            }
        }

        public override void Update(GameTime gameTime)
        {
            this.FindPath();
            this.ManageMovement();

            if (this.Y > 720)
            {
                this.X = 0;
                this.Y = 80;
            }

            this.UpdateBoundingBox();
            this.ManageAnimation(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.SpriteSheet, 
                new Rectangle((int)this.X, (int)this.Y, PrincessDestRectSize, PrincessDestRectSize), 
                this.SourceRect, 
                Color.White);
            //spriteBatch.Draw(TextureLoader.TheOnePixel, this.Position, 
            //    new Rectangle((int)this.X, (int)this.Y, PrincessDestRectSize, PrincessDestRectSize), Color.Blue);
        }
    }
}
