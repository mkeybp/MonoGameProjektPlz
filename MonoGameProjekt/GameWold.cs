using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameProjekt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 



    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D playerTexture;
        private Player sprite;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("Player");

            sprite = new Player(playerTexture)
            {
                position = new Vector2(100, 100),
                origin = new Vector2(playerTexture.Width / 2, playerTexture.Height - 75),
            };
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
            sprite.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            sprite.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }







    //public class GameWorld : Game
    //{

    //    int screenWidth;
    //    int screenHeight;

    //    Texture2D maleSprite;

    //    private List<GameObject> gameObjects = new List<GameObject>();

    //    public static Vector2 screenSize;






    //    GraphicsDeviceManager graphics;
    //    SpriteBatch spriteBatch;

    //    public GameWorld()
    //    {
    //        graphics = new GraphicsDeviceManager(this);
    //        Content.RootDirectory = "Content";

    //    }

    //    /// <summary>
    //    /// Allows the game to perform any initialization it needs to before starting to run.
    //    /// This is where it can query for any required services and load any non-graphic
    //    /// related content.  Calling base.Initialize will enumerate through any components
    //    /// and initialize them as well.
    //    /// </summary>
    //    protected override void Initialize()
    //    {
    //        graphics.PreferredBackBufferWidth = 1000;
    //        graphics.PreferredBackBufferHeight = 1000;
    //        graphics.IsFullScreen = false;
    //        graphics.ApplyChanges();
    //        Window.Title = "MonogameProject";

    //        base.Initialize();
    //    }

    //    /// <summary>
    //    /// LoadContent will be called once per game and is the place to load
    //    /// all of your content.
    //    /// </summary>
    //    protected override void LoadContent()
    //    {
    //        // Create a new SpriteBatch, which can be used to draw textures.
    //        spriteBatch = new SpriteBatch(GraphicsDevice);

    //        maleSprite = Content.Load<Texture2D>("player_fwd");

    //        // TODO: use this.Content to load your game content here
    //    }

    //    /// <summary>
    //    /// UnloadContent will be called once per game and is the place to unload
    //    /// game-specific content.
    //    /// </summary>
    //    protected override void UnloadContent()
    //    {
    //        // TODO: Unload any non ContentManager content here
    //    }

    //    /// <summary>
    //    /// Allows the game to run logic such as updating the world,
    //    /// checking for collisions, gathering input, and playing audio.
    //    /// </summary>
    //    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    //    protected override void Update(GameTime gameTime)
    //    {
    //        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
    //            Exit();

    //        // TODO: Add your update logic here

    //        base.Update(gameTime);
    //    }

    //    /// <summary>
    //    /// This is called when the game should draw itself.
    //    /// </summary>
    //    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    //    protected override void Draw(GameTime gameTime)
    //    {
    //        GraphicsDevice.Clear(Color.CornflowerBlue);

    //        // TODO: Add your drawing code here
    //        spriteBatch.Begin();
    //        DrawPlayer();
    //        spriteBatch.End();
    //        base.Draw(gameTime);
    //    }

    //    private void DrawPlayer()
    //    {

    //        spriteBatch.Draw(maleSprite, new Vector2(1, 2), Color.White);

    //    }
    //}
}