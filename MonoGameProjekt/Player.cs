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
    public class Player
    {

        private float rotation;

        public Vector2 position;

        public Texture2D playerTexture;
        private Vector2 direction;

        /// <summary>
        /// The point we rotate on
        /// </summary>
        public Vector2 origin;

        /// <summary>
        /// The speed of the rotation
        /// </summary>
        public float rotationVelocity = 3f;

        /// <summary>
        /// The speed of moving forward
        /// </summary>
        public float linearVelocity = 4f;

        public Player(Texture2D texture)
        {
            playerTexture = texture;
        }

        public void Update()
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 0f);
        }
    }
}