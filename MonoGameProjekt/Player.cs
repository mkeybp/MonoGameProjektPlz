using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProjekt
{
    class Player : GameObject
    {
        //protected List<int> weapons = new List<int>;


        private Vector2 direction;
        public float rotationVelocity = 3f;
        public float linearVelocity = 4f;

        public int playerHealth;
        public int score;
        public float speed;

        private static Vector2 playerPosition;

        public static Vector2 PlayerPosition
        {
            get
            {
                return playerPosition;
            }
            set
            {
                playerPosition = value;
            }
        }

        public Player()
        {
            speed = 500f;
        }
        /// <summary>
        /// Loader spiller sprites.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[1];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("player_fwd");
            }
            sprite = sprites[0];

            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            this.position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y - (sprite.Height / 2));

        }
        private void Animate()
        {
            while()
            {

            }
        }
        /// <summary>
        /// Tjekker for inputs hver frame.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);
            HandleScore();
            SelectWeapon();
            CameraFollow();
            playerPosition = this.position;
        }
        /// <summary>
        /// Score.
        /// </summary>
        private void HandleScore()
        {

        }
        /// <summary>
        /// Bevæger spilleren når man trykker på de givne taster.
        /// </summary>
        private void HandleInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                rotation -= MathHelper.ToRadians(rotationVelocity);
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                rotation += MathHelper.ToRadians(rotationVelocity);
            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                position += direction * linearVelocity;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                position -= direction * linearVelocity;
        }
        /// <summary>
        /// Gør at man går samme hastighed ligegyldigt at fps.
        /// </summary>
        /// <param name="gameTime"></param>
        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        /// <summary>
        /// Gør at kameraet følger spilleren.
        /// </summary>
        private void CameraFollow()
        {

        }
        /// <summary>
        /// Lader dig skifte våben
        /// </summary>
        private void SelectWeapon()
        {

        }
        /// <summary>
        /// Lader dig gå ud fra siden af mappet og komme ind på den anden side.
        /// </summary>
        /*private void ScreenWarp()
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
        }*/
    }
}