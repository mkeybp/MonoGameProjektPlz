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
        // For enemy health
        protected int enemyHealth;
        // Count's the number of enemies (for adding more enemies)
        private int enemyCounter;
        // Timer for spawning of a new enemy
        private int spawnTimer = 300;
        // Distance
        private Vector2 distance;
        // Direction of the enemy
        private Vector2 direction;
        public Enemy(string spriteName, Vector2 pos) : base(spriteName, pos)
        {
        }
        /// <summary>
        /// Updates the Spawn and Move classes
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Spawn();
            Move(gameTime);
        }
        /// <summary>
        /// Loads the content
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            // Load's enemy's sprite
            sprite = content.Load<Texture2D>("enemy1");
            // The center of the enemy
            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            // Spawn position of all enemies
            this.position = new Vector2(0, 0);


            // Random enemy spawn
            //this.position = new Vector2(GameWorld.ScreenSize.X / 2 + rnd.Next(200, 500), GameWorld.ScreenSize.Y - (sprite.Height / 2 + rnd.Next(200, 500)));

            // The speed of the rotation
            velocity = new Vector2(rotation);
            // the speed of the enemy
            this.speed = 2f;
        }
        /// <summary>
        /// Method for enemy movement
        /// </summary>
        /// <param name="gameTime"></param>
        private void Move(GameTime gameTime)
        {
            // Calculates the distance from the player and the enemy
            distance.X = Player.PlayerPosition.X - position.X;
            distance.Y = Player.PlayerPosition.Y - position.Y;

            rotation = (float)Math.Atan2(distance.X, -distance.Y);

            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            float positiveDistanceX = distance.X;
            float positiveDistanceY = distance.Y;
            if (distance.X < 0)
            {
                positiveDistanceX *= -1;

            }
            if (distance.Y < 0)
                positiveDistanceY *= -1;

            if (positiveDistanceX > 50 || positiveDistanceY > 50)
                position += direction * this.speed;


        }
        /// <summary>
        /// Method for spawning enemies
        /// </summary>
        private void Spawn()
        {
            enemyCounter++;
            if (enemyCounter > spawnTimer)
            {
                GameWorld.Instanciate(new Enemy("", Vector2.Zero));
                enemyCounter = 0;
            }

        }
    }
}