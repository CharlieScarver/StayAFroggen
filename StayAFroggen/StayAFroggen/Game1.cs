namespace StayAFroggen
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using TextureLoading;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Timer.Timer cleanTimer;
        private Timer.Timer spawnTimer;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //this.Window.IsBorderless = true;
            //this.graphics.IsFullScreen = true;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.ApplyChanges();
           
            Engine.InitializeGameObjects();
            Engine.InitializeLevel("1");

            cleanTimer = new Timer.Timer();
            spawnTimer = new Timer.Timer();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureLoader.Load(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))// || !player.IsActive)
                Exit();

            if (this.cleanTimer.CheckIfReady(gameTime))
            {
                Engine.CleanInactiveUnits();
                Engine.CleanInactiveProjectiles();
                this.cleanTimer.SetTimer(gameTime, 0.5);
            }

            if (this.spawnTimer.CheckIfReady(gameTime))
            {
                Engine.InitializeGameObjects(); //kek
                this.spawnTimer.SetTimer(gameTime, 2);
            }

            foreach (IUnit unit in Engine.Units)
            {
                if (unit.IsActive)
                {
                    unit.Update(gameTime);
                }
                else
                {
                    unit.Nullify();
                }
            }

            foreach (ITower tower in Engine.Towers)
            {
                if (tower.IsActive)
                {
                    tower.Update(gameTime);
                }
                else
                {
                    tower.Nullify();
                }
            }

            foreach (IProjectile projectile in Engine.Projectiles)
            {
                if (projectile.IsActive)
                {
                    projectile.Update(gameTime);
                }
                else
                {
                    projectile.Nullify();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            //spriteBatch.Draw(
            //    TextureLoader.Background, 
            //    new Rectangle(
            //        0, 
            //        0, 
            //        this.graphics.GraphicsDevice.Viewport.Width, 
            //        this.graphics.GraphicsDevice.Viewport.Height), 
            //    Color.White);

            foreach (ITile tile in Engine.Tiles)
            {
                tile.Draw(this.spriteBatch);
            }

            foreach (IUnit unit in Engine.Units)
            {
                if (unit.IsActive)
                {
                    unit.Draw(this.spriteBatch);
                    //unit.DrawBb(this.spriteBatch, Color.Bisque);
                }
            }

            foreach (IProjectile projectile in Engine.Projectiles)
            {
                if (projectile.IsActive)
                {
                    projectile.Draw(this.spriteBatch);
                    //projectile.DrawBb(this.spriteBatch, Color.Bisque);
                }
            }

            foreach (ITower tower in Engine.Towers)
            {
                if (tower.IsActive)
                {
                    tower.Draw(this.spriteBatch);
                    //tower.DrawBb(this.spriteBatch, Color.Bisque);
                }
            }

            this.spriteBatch.End();
        }
    }
}
