using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1.Classes
{
   public class Jogador : GameObject
    {
       public float speed = 5;
       public float limit;
       public int score = 0;

      /* public static List<Jogador> Find()
       {
           List<Jogador> j = new List<Jogador>();
         foreach(Jogador f in GameObject.instances)
         {
             if (j is Jogador)
             {
                 j.Add(f);
             }
         }
         return j;
       }*/

       public Jogador(float a )
       {
           limit = a;
       }
       

       public void Move(Keys a, Keys b)
       {
           KeyboardState k = Keyboard.GetState();
           Console.WriteLine(Position.Y);
           if (k.IsKeyDown(a) && Position.Y > 0) Position += new Vector2(0, -speed);

           if (k.IsKeyDown(b) && Position.Y < limit) Position += new Vector2(0, speed);

       }
    }

}
