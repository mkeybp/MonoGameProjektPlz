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
    abstract class GameObject
    {
        protected Vector2 velocity;

        protected float speed;

        protected Vector2 position;

        protected Texture2D[] sprites;

        protected Texture2D sprite;

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);



    }
}