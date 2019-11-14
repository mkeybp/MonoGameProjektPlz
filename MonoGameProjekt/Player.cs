using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Projekt;

namespace MonoGameProjekt
{
    /// <summary>
    /// Player inherits from GameObject
    /// </summary>
    class Player : GameObject
    {
        // Direction of the player
        private Vector2 direction;
        // Rotation spped
        public float rotationVelocity = 3f;
        // Speed of movemenet
        public float linearVelocity = 4f;
        // Score to be
        public int score;
        // The speed of the player
        public float speed;

        // Player's current position
        private static Vector2 playerPosition;
        public static Vector2 PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }
        // Player's current rotation
        private static float playerRotation;
        private Texture2D defaultSprite;

        public static float PlayerRotation
        {
            get { return playerRotation; }
            set { playerRotation = value; }
        }

        public Player(string spriteName, Vector2 pos) : base(spriteName, pos)
        {
            speed = 500f;
        }
        /// <summary>
        /// Load's all player sprites
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[5];
            // Loop's through the sprite array to create an animation
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + "playernew");
            }

            fps = 5;
            // Default sprite (for standing still)
            sprite = sprites[0];
            // The center of the player
            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            // The start position of the player
            this.position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);

        }
        /// <summary>
        /// Check's for input every frame
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
            HandleScore();
            ScreenWarp();

            SelectWeapon();
            CameraFollow();
            playerPosition = this.position;
            playerRotation = this.rotation;
        }
        /// <summary>
        /// Score to be
        /// </summary>
        private void HandleScore()
        {

        }
        /// <summary>
        /// Handles key input from player for movement, animation and shooting
        /// </summary>
        private void HandleInput(GameTime gameTime)
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                rotation -= MathHelper.ToRadians(rotationVelocity);
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                rotation += MathHelper.ToRadians(rotationVelocity);
            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                position += direction * linearVelocity;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                position -= direction * linearVelocity;
            // Only animates when W and S (forward an backward) are pressed
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Animate(gameTime);
            }
            // If neither W or S are pressed, use defalut sprite (standing still)
            else if (!Keyboard.GetState().IsKeyDown(Keys.W) || !Keyboard.GetState().IsKeyDown(Keys.S))
            {
                sprite = sprites[0];
            }

            // Player shoot 
            if (currentKey.IsKeyDown(Keys.Space) && !previousKey.IsKeyDown(Keys.Space))
            {
                GameWorld.Instanciate(new Bullet("", Vector2.Zero));
            }
        }
        /// <summary>
        /// Makes movement same speed no matter how many frames you've got
        /// </summary>
        /// <param name="gameTime"></param>
        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        /// <summary>
        /// Camera follow's the player (player is centered)
        /// </summary>
        private void CameraFollow()
        {

        }
        /// <summary>
        /// Weapon selection
        /// </summary>
        private void SelectWeapon()
        {


        }
        /// <summary>
        /// Makes it possible to move out of the map and enter on det opposite side
        /// </summary>
        private void ScreenWarp()
        {
            if (position.X > GameWorld.ScreenSize.X + sprite.Width)
            {
                position.X = -sprite.Width;
            }
            else if (position.X < -sprite.Width)
            {
                position.X = GameWorld.ScreenSize.X + sprite.Width;
            }
            if (position.Y > GameWorld.ScreenSize.Y + sprite.Height)
            {
                position.Y = -sprite.Height;
            }
            else if (position.Y < -sprite.Height)
            {
                position.Y = GameWorld.ScreenSize.Y + sprite.Height;
            }
        }
    }
}