﻿using System.Collections.Generic;
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

        private Vector2 distance;
        private Vector2 direction;

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[1]; 

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>("enemy" + (i + 1));
            }
            sprite = sprites[0];
            Respawn();

            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            this.position = new Vector2(GameWorld.ScreenSize.X / 2 + 200, GameWorld.ScreenSize.Y - (sprite.Height / 2));

        }

        private void Move(GameTime gameTime)
        {
            //velocity = new Vector2(- Player.PlayerPosition.X, - Player.PlayerPosition.Y);

            distance.X = Player.PlayerPosition.X - position.X;
            distance.Y = Player.PlayerPosition.Y - position.Y;

            rotation = (float)Math.Atan2( distance.X, -distance.Y);
            
            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            float positiveDistanceX = distance.X;
            float positiveDistanceY = distance.Y;
            if (distance.X < 0)
                positiveDistanceX *= -1;
            if (distance.Y < 0)
                positiveDistanceY *= -1;

            if (positiveDistanceX > 50 || positiveDistanceY > 50)
                position += direction * 2;


        }



        private void Respawn()
        {
            velocity = new Vector2(rotation);
            speed = 10f;
            //position = new Vector2(random.Next(0,1000),random.Next(0,1000));
        }

    }
}