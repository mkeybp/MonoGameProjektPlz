﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameProjekt
{
    abstract class GameObject
    {
        protected Vector2 velocity;

        protected float speed;

        protected Vector2 position;

        protected Texture2D[] sprites;

        protected Texture2D sprite;

        protected Vector2 origin;

        protected float rotation;
        protected int scaleFactor = 1;
        protected Color rendercolor = new Color(255, 255, 255, 255);

        protected Rectangle top;
        protected Rectangle bottom;
        protected Rectangle right;
        protected Rectangle left;

        protected int collisionOffset = 0;

        public Texture2D Sprite { get => sprite; set => sprite = value;  }
        public Color RenderColor { get => rendercolor; set => rendercolor = value; }

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Middle
        {
            get
            {
                Vector2 mid = position;
                mid.X += Width / 2;
                mid.Y += Height / 2;
                return mid;
            }
        }

        public int ScaleFactor { get => scaleFactor; set => scaleFactor = value; }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width * (int)scaleFactor, sprite.Height * (int)scaleFactor);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 0);
        }

        public virtual int Width
        {
            get
            {
                return CollisionBox.Width;
            }
        }
        public virtual int Height
        {
            get
            {
                return CollisionBox.Height;
            }
        }

    }
}
