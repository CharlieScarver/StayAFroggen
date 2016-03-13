namespace StayAFroggen.GameObjects.Towers
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class Tower : GameObject, ITower
    {
        protected Tower() : base()
        {

        }

        public float Range { get; protected set; }

        public int Damage { get; protected set; }

        public void Attack(IUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Update(GameTime gameTime);
    }
}
