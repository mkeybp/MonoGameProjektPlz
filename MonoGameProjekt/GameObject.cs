using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameProjekt
{
    public abstract class GameObject
    {
        protected Vector2 velocity;

        protected float speed;

        protected Vector2 position;

        protected Texture2D[] sprites;

        protected Texture2D sprite;

        protected Vector2 origin;

        protected float rotation;

        private float timeElapsed;

        private int currentIndex;

        protected int fps;




        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 1);
        }

        protected void Animate(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentIndex = (int)(timeElapsed * fps);
            sprite = sprites[currentIndex];
            
            if(currentIndex >= sprites.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }

        }

    }
}