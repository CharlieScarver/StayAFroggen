﻿namespace StayAFroggen.Timer
{
    using Microsoft.Xna.Framework;

    public class Timer
    {
        private double startCount;
        private double endCount;

        public Timer()
        {
            this.IsActive = false;
            this.IsComplete = true;
            this.startCount = 0;
            this.endCount = 0;
        }

        public void SetTimer(GameTime gameTime, double seconds)
        {
            this.startCount = gameTime.TotalGameTime.TotalSeconds;
            this.endCount = this.startCount + seconds;
            this.IsActive = true;
            this.IsComplete = false;
        }

        public bool CheckIfReady(GameTime gameTime)
        {
            if (!this.IsComplete)
            {
                if (gameTime.TotalGameTime.TotalSeconds > this.startCount)
                {
                    if (gameTime.TotalGameTime.TotalSeconds >= this.endCount)
                    {
                        this.endCount = 0;
                        this.IsComplete = true;
                    }
                }
            }
            return this.IsComplete;
        }

        public bool IsActive { get; private set; }
        public bool IsComplete { get; private set; }
    }
}
