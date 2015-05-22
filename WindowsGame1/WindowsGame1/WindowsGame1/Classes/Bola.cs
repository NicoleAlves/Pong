using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.Classes;

namespace WindowsGame1.Classes
{
    public class Bola : GameObject
    {
        public Vector2 Velocity;
        public Random random;

        public Bola()
        {
            random = new Random();
        }

        public void Lauch(float speed)
        {
            Position = new Vector2(Game1.screenWidth / 2 - Texture.Width / 2, Game1.screenHeight / 2 - Texture.Height / 2);
            float rotation = (float) (Math.PI/2 + (random.NextDouble() * (Math.PI/1.5f) - Math.PI/3));

            Velocity.X = (float) Math.Sin(rotation);
            Velocity.Y = (float) Math.Cos(rotation);

            if(random.Next(2) == 1)
            {
                Velocity.X *= -1; //launch to the left 
            }

            Velocity *= speed;
        }

        public void CheckWallCollision()
        {
            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }

            if (Position.Y + Texture.Height > Game1.screenHeight)
            {
                Position.Y = Game1.screenHeight - Texture.Height;
                Velocity.Y *= -1;
            }

            if (Position.X < 0)
            {
                Lauch(Game1.BALL_START_SPEED);
                Game1.score2 += 1;
                
            }

            if (Position.X + Texture.Width > Game1.screenWidth)
            {
                Lauch(Game1.BALL_START_SPEED);
                Game1.score1 += 1;
            }
        }

        public void CheckCollisionJog(Jogador jog)
        {
            if (Position.X + Texture.Width > jog.Position.X &&
                Position.X < jog.Position.X + jog.Texture.Width &&
                Position.Y + Texture.Height > jog.Position.Y && 
                Position.Y < jog.Position.Y + jog.Texture.Height)
            {
                this.Velocity.X *= -1;

                if (this.Velocity.X > 0)
                {
                    this.Velocity.X++;
                }
                if (this.Velocity.X < 0)
                {
                    this.Velocity.X--;
                }
            }
        }
    }
}
