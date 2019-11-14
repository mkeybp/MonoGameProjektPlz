using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameProjekt
{
    public abstract class GameObject
    {
        // The speed of the rotation
        protected Vector2 velocity;
        // Enemy speed
        protected float speed;
        // Current and start position
        protected Vector2 position;
        // Sprites for animation of player
        protected Texture2D[] sprites;
        // Sprite for Bullet and Enemy
        protected Texture2D sprite;
        // Center of a sprite
        protected Vector2 origin;
        // Rotation of player and enemy
        protected float rotation;
        // Scaling of Collision Rectangles
        protected int scaleFactor = 1;
        // Rectangles for collision
        protected Rectangle top;
        protected Rectangle bottom;
        protected Rectangle right;
        protected Rectangle left;

        private float timeElapsed;

        private int currentIndex;

        protected int fps;

        // For making a delay on key presses (making shooting not to spammable)
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;

        //protected int collisionOffset = 0;

        //public Texture2D Sprite { get => sprite; set => sprite = value; }
        //public Color RenderColor { get => rendercolor; set => rendercolor = value; }

        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Makes the center of the sprite (collision boxes)
        /// </summary>
        public Vector2 Middle
        {
            get
            {

                Vector2 mid = position;
                mid.X -= Width / 2;
                mid.Y -= Height / 2;
                return mid;
            }
        }

        public int ScaleFactor { get => scaleFactor; set => scaleFactor = value; }

        public GameObject(string spriteName, Vector2 pos)
        {
            position = pos;
        }
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
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

        public bool IsColliding(GameObject otherObj)
        {
            return CollisionBox.Intersects(otherObj.CollisionBox);
        }

        public virtual void DoCollision(GameObject otherObj)
        {
        }
        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 1);
        }
        /// <summary>
        /// Places the collision boxes
        /// </summary>
        protected virtual void SetCollisionRects()
        {
            Rectangle cBox = CollisionBox;

            top = new Rectangle((int)Middle.X, (int)Middle.Y, cBox.Width * (int)scaleFactor, 1);
            bottom = new Rectangle((int)Middle.X, (int)Middle.Y + cBox.Height * (int)scaleFactor, cBox.Width * (int)scaleFactor, 1);
            right = new Rectangle((int)Middle.X + cBox.Width * (int)scaleFactor, (int)Middle.Y, 1, cBox.Height * (int)scaleFactor);
            left = new Rectangle((int)Middle.X, (int)Middle.Y, 1, cBox.Height * (int)scaleFactor);
        }
        /// <summary>
        /// Draws the collision boxes
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="collisionTex"></param>
        public virtual void DrawCollisionBox(SpriteBatch spriteBatch, Texture2D collisionTex)
        {

            SetCollisionRects();
            spriteBatch.Draw(collisionTex, top, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, bottom, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, right, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, left, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);

        }

        /// <summary>
        /// Animates the player
        /// </summary>
        /// <param name="gameTime"></param>
        protected void Animate(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentIndex = (int)(timeElapsed * fps);
            sprite = sprites[currentIndex];

            if (currentIndex >= sprites.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }

        }

    }
}