namespace StayAFroggen.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IBuilder : IUnit
    {
        bool TowerToBuild { get; set; }

        void BuildTower(GameTime gameTime);
    }
}
