namespace StayAFroggen.Interfaces
{
    using Structures;

    public interface IProjectile : IGameObject, IUpdateable
    {
        VelocityXY Velocity { get; }

        IPrincess Target { get; }

        int Damage { get; }
    }
}
