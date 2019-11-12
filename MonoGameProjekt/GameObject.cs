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
    public class GameObject
    {

        protected Texture2D sprite;
        protected float rotation;
        protected Vector2 position;
        public Vector2 Position { get => position; }

        protected ContentManager content;

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width * 0.5), (int)(position.Y - sprite.Height * 0.5), sprite.Width, sprite.Height);
            }
        }


        public bool IsColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }

        public virtual void DoCollision(GameObject otherObject)
        {

        }

        public GameObject(ContentManager content, string spriteName) : this(Vector2.Zero, content, spriteName)
        {
            this.content = content;
        }

        public GameObject(Vector2 startPosition, ContentManager content, string spriteName)
        {
            position = startPosition;
            sprite = content.Load<Texture2D>(spriteName);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0f);


        }
    }
}