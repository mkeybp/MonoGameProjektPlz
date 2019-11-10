using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameProjekt;

namespace Monogame_Projekt
{
    class Enemy : GameObject
    {
        private Random random;
        protected int health;



        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[4];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("enemy" + (i + 1));
            }
            sprite = sprites[0];
            Respawn();

            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            this.position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y - (sprite.Height / 2));
        }

        private void Move(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }

        private void Respawn()
        {
            //velocity = todo: add player position
            speed = 100f;
            //position = new Vector2(random.Next(0,1000),random.Next(0,1000));
        }

    }
}