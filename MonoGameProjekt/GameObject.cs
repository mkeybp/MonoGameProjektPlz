using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        protected int scaleFactor = 1;

        protected Color rendercolor = new Color(255, 255, 255, 255);

        protected Rectangle top;
        protected Rectangle bottom;
        protected Rectangle right;
        protected Rectangle left;

        private float timeElapsed;

        private int currentIndex;

        protected int fps;
        
        protected int collisionOffset = 0;

        protected KeyboardState currentKey;

        protected KeyboardState previousKey;



        //public Texture2D Sprite { get => sprite; set => sprite = value; }
        //public Color RenderColor { get => rendercolor; set => rendercolor = value; }

        public Vector2 Position { get => position; set => position = value; }
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

            //spriteBatch.Draw(sprite, position - GameWorld.Camera, sprite.Bounds, rendercolor, 0f, new Vector2(0, 0), new Vector2(scaleFactor, scaleFactor), SpriteEffects.None, 0f);
        }
        protected virtual void SetCollisionRects()
        {
            Rectangle cBox = CollisionBox;
            //top = new Rectangle((int)Middle.X, (int)Middle.Y, cBox.Width * (int)scaleFactor, 1);


            top = new Rectangle((int)Middle.X, (int)Middle.Y, cBox.Width * (int)scaleFactor, 1);
            bottom = new Rectangle((int)Middle.X, (int)Middle.Y + cBox.Height * (int)scaleFactor, cBox.Width * (int)scaleFactor, 1);
            right = new Rectangle((int)Middle.X + cBox.Width * (int)scaleFactor, (int)Middle.Y, 1, cBox.Height * (int)scaleFactor);
            left = new Rectangle((int)Middle.X, (int)Middle.Y, 1, cBox.Height * (int)scaleFactor);
        }

        public virtual void DrawCollisionBox(SpriteBatch spriteBatch, Texture2D collisionTex)
        {

            SetCollisionRects();
            spriteBatch.Draw(collisionTex, top, null, Color.Black,0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, bottom, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, right, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTex, left, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 1);

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