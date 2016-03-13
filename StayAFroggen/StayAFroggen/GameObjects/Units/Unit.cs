namespace StayAFroggen.GameObjects.Units
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class Unit : GameObject, IUnit
    {
        protected Unit() : base()
        {
            this.IsMovingUp = false;
            this.IsMovingDown = false;
            this.IsMovingRight = false;
            this.IsMovingLeft = false;
        }

        public float MovementSpeed { get; protected set; }
        public bool IsMovingUp { get; set; }
        public bool IsMovingDown { get; set; }
        public bool IsMovingRight { get; set; }
        public bool IsMovingLeft { get; set; }

        public abstract void Update(GameTime gameTime);
    }
}
