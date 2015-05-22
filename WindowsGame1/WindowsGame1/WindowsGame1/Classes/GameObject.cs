using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Classes
{
    public class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;
        public int w;
        public int h;
        public static List<GameObject> instances = new List<GameObject>();
        
        public GameObject()
        {
            instances.Add(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }
    }
}
