namespace StayAFroggen.GameObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Structures;

    public abstract class Projectile : GameObject, IProjectile
    {
        protected Projectile() : base()
        {
            
        }

        public VelocityXY Velocity { get; protected set; }

        public IPrincess Target { get; protected set; }

        public int Damage { get; protected set; }

        public abstract void Update(GameTime gameTime);

        
    }
}
