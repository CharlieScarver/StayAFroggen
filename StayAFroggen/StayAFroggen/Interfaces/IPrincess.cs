namespace StayAFroggen.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IPrincess : IDestroyable, IAnimatable
    {
        Rectangle WalkingBox { get; }

        int WalkingBoxX { get; set; }

        int WalkingBoxY { get; set; }
    }
}
