namespace StayAFroggen.Interfaces
{
    public interface IAttacker
    {
        float Range { get; }

        int Damage { get; }

        void Attack(IUnit unit);
    }
}
