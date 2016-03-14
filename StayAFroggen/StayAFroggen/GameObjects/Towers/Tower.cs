namespace StayAFroggen.GameObjects.Towers
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Projectiles;
    using Structures;
    using Timer;

    public abstract class Tower : GameObject, ITower
    {
        protected Tower() : base()
        {

        }

        protected Timer AttackTimer { get; set; }
        protected float AttackTimeInSeconds { get; set; }

        public float Range { get; protected set; }

        public int Damage { get; protected set; }


        public abstract void Attack(IPrincess unit);

        public abstract void Update(GameTime gameTime);
    }
}
