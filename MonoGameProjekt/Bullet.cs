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
    public class Bullet : GameObject
    {
        private Vector2 direction;

        public Bullet(string spriteName, Vector2 pos) : base(spriteName, pos)
        {

        }
        public override void LoadContent(ContentManager content)
        {

            //sprites = new Texture2D[] {
            //    content.Load<Texture2D>("Bullet") };
            //sprite = sprites[0];
            sprite = content.Load<Texture2D>("Bullet");
            

            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
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
            position += direction * 10;
        }
    }
}
