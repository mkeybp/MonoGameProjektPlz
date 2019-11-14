using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Projekt;
using System.Collections.Generic;

namespace MonoGameProjekt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        int screenWidth;
        int screenHeight;

        public static List<GameObject> gameObjects;
        public static List<GameObject> newObjects;

        //Texture2D backgroundTexture;
        static Texture2D collisionTex;
        public static Vector2 Camera { get; set; } = new Vector2(0, 0);
        public static Texture2D CollisionTex { get => collisionTex; }

        public static Vector2 screenSize;
        public static Vector2 ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }


        public SpriteFont font;
        protected int score = 0;
        protected int playerHealth = 100;
        private Texture2D background;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        static ContentManager ContentInstance;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);

            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            Content.RootDirectory = "Content";
            ContentInstance = Content;

        }

        public static void Instanciate(GameObject gameObject)
        {
            gameObject.LoadContent(ContentInstance);
            newObjects.Add(gameObject);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            screenSize.X = 1000;
            screenSize.Y = 1000;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "MonogameProject";

            gameObjects = new List<GameObject>();
            newObjects = new List<GameObject>();
            gameObjects.Add(new Player("", Vector2.Zero));
            gameObjects.Add(new Enemy("", Vector2.Zero));
            gameObjects.Add(new Bullet("", Vector2.Zero));
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
            device = graphics.GraphicsDevice;

            font = Content.Load<SpriteFont>("PlayerHealth");
            font = Content.Load<SpriteFont>("Score");
            background = Content.Load<Texture2D>("grass_backgroundnew");

            // Mikkel Bakground
            //backgroundTexture = Content.Load<Texture2D>("grass");
            collisionTex = Content.Load<Texture2D>("CollisionTex");
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            foreach (GameObject go in gameObjects)
            {
                go.LoadContent(Content);
            }

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (GameObject go in gameObjects)
            {
                go.Update(gameTime);
            }
            gameObjects.AddRange(newObjects);
            newObjects.Clear();

            base.Update(gameTime);

            

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            // Collision boxes
            DrawScenery();

            spriteBatch.DrawString(font, "Player Health: " + playerHealth, new Vector2(0, 0), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Monsters Killed: " + score, new Vector2(0, 22), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);


            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
                gameObject.DrawCollisionBox(spriteBatch, collisionTex);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawCollisionBoxes()
        {
        }

        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            //spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
        }

    }
}