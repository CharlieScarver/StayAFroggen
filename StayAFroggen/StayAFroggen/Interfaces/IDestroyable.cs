namespace StayAFroggen.Interfaces
{
    public interface IDestroyable
    {
        int Health { get; }

        void GetHit(int damage);
    }
}
