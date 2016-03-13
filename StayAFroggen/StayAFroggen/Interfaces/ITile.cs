namespace StayAFroggen.Interfaces
{
    using Enumerations;

    public interface ITile : IGameObject
    {
        TileType Type { get; }
    }
}
