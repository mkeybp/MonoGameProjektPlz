using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProjekt
{

    class Bullet : GameObject
    {
        private Vector2 direction;
        private const float bulletSpeed = 200;

        public Bullet(Vector2 direction, Vector2 startPosition, ContentManager content) : base(startPosition,content, "bullet")
        {
            this.direction = direction;
            this.direction.Normalize();
        }

        /// <summary>
        /// Moves the Bullet in the designated direction. If it goes outside the screen area it gets removed
        /// </summary>
        /// <param name="gameTime">The elasped time since last update call</param>
        public override void Update(GameTime gameTime)
        {
            position += direction * (float)(bulletSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (!GameWorld.ScreenSize.Intersects(CollisionBox))
            {
                GameWorld.RemoveGameObject(this);
            }
        }

        
    }
}
