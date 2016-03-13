namespace StayAFroggen.GameObjects.Projectiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class Projectile : GameObject, IProjectile
    {
        protected Projectile() : base()
        {
            
        }

        public float MovementSpeed { get; }

        public abstract void Update(GameTime gameTime);
        
    }
}
