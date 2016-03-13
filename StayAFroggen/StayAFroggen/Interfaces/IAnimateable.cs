namespace StayAFroggen.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IAnimatable : IDrawable
    {
        int CurrentFrame { get; }

        int BasicAnimationFrameCount { get; }

        double Timer { get; }

        int Delay { get; }

        Rectangle SourceRect { get; }
    }
}
