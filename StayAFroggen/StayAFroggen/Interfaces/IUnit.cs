namespace StayAFroggen.Interfaces
{
    public interface IUnit : IGameObject, IUpdateable, IMoveable
    {
        bool IsMovingUp { get; set; }

        bool IsMovingDown { get; set; }

        bool IsMovingRight { get; set; }

        bool IsMovingLeft { get; set; }
        
    }
}
