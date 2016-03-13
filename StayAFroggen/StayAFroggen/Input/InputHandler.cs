namespace StayAFroggen.Input
{
    using System.Runtime.CompilerServices;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using StayAFroggen.GameObjects.Units;
    using Interfaces;

    public static class InputHandler
    {
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        public static void HandleInput(GameTime gameTime, IBuilder builder)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.GetPressedKeys().Length == 0)
            {
                builder.IsMovingUp = false;
                builder.IsMovingDown = false;
                builder.IsMovingRight = false;
                builder.IsMovingLeft = false;
            }

            // Move Up & Down
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                builder.IsMovingUp = true;
                builder.IsMovingDown = false;
            }
            else if (!currentKeyboardState.IsKeyDown(Keys.Up))
            {
                builder.IsMovingUp = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                builder.IsMovingDown = true;
                builder.IsMovingUp = false;
            }
            else if (!currentKeyboardState.IsKeyDown(Keys.Down))
            {
                builder.IsMovingDown = false;
            }

            // Move Right & Left
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                builder.IsMovingRight = true;
                builder.IsMovingLeft = false;
            }
            else if (!currentKeyboardState.IsKeyDown(Keys.Right))
            {
                builder.IsMovingRight = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                builder.IsMovingLeft = true;
                builder.IsMovingRight = false;
            }
            else if (!currentKeyboardState.IsKeyDown(Keys.Left))
            {
                builder.IsMovingLeft = false;
            }

            // Build
            if (currentKeyboardState.IsKeyDown(Keys.Q))
            {
                builder.TowerToBuild = true;
            }
        }

    }
}
