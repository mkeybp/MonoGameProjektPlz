using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProjekt
{   
    /// <summary>
     /// Bullet inherits from GameObject
     /// </summary>
    class Bullet : GameObject
    {
        // Direction of the bullet calculated by the rotation of the player
        private Vector2 direction;
        // Speed of the bullet
        private int bulletSpeed = 10;

        public Bullet(string spriteName, Vector2 pos) : base(spriteName, pos)
        {         
        }
        public override void LoadContent(ContentManager content)
        {
            // Loads the Bullet sprite
            sprite = content.Load<Texture2D>("Bullet");
            // "Fires" the bullet from the center of the player
            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            // "Fires" the bullet from the position of the player
            this.position = new Vector2(Player.PlayerPosition.X, Player.PlayerPosition.Y);
            this.rotation = Player.PlayerRotation;
        }
        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            
            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));
            // The position it's fired form and in which  direction, multiplied by the bullet speed (10)
            position += direction * bulletSpeed;
        }
    }
}
