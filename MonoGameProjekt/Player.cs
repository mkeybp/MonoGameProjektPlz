using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
        public int playerHealth;
        public int score;
        public float speed;

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
            sprites = new Texture2D[4];

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
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
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